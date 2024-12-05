using System.Collections.Generic;
using System.Linq;
using _Project.Data.Items;
using _Project.Source;
using _Project.Source.Dungeon.Battle;
using _Project.Source.Scenes;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class FieldData
{
    // initial party setup
    public Party<DungeonHero> heroParty = new();
    public Party<DungeonMonster> monsterParty = new();

    // current party setup
    public List<DungeonCharacter> remainingHeroes = new();
    public List<DungeonCharacter> remainingMonsters = new();

    // current round's actors to act
    public List<DungeonCharacter> actors = new();

    public void CalculateRemainingActors()
    {
        Debug.Log("New round started");
        actors.Clear();
        remainingHeroes.Clear();
        remainingHeroes.AddRange(heroParty.GetParticipating());
        actors.AddRange(remainingHeroes);
        remainingMonsters.Clear();
        remainingMonsters.AddRange(monsterParty.GetParticipating());
        actors.AddRange(remainingMonsters);
    }

    public DungeonCharacter PopActor()
    {
        DungeonCharacter pop = null;
        do
        {
            if (actors.Count == 0)
            {
                CalculateRemainingActors();
            }

            pop = actors.Pop();
        } while (!pop.IsParticipating());

        return pop;
    }

    public List<DungeonCharacter> GetEnemyTargets(DungeonCharacter actor)
    {
        return (actor is DungeonHero ? remainingMonsters : remainingHeroes).Where(c => c.IsParticipating())
            .ToList();
    }

    public List<DungeonCharacter> GetAllyTargets(DungeonCharacter actor)
    {
        return (actor is DungeonHero ? remainingHeroes : remainingMonsters).Where(c => c.IsParticipating())
            .ToList();
    }

    public static async UniTask<float> TryAttack(DungeonCharacter dcaster, DungeonCharacter dtarget)
    {
        Unit caster = dcaster.unit;
        Unit target = dtarget.unit;

        // Check if the attack hits
        var r = Random.value;
        if (r > caster.HitChance - target.Evasion)
        {
            await dcaster.ChangeMorale(-1);

            if (r > caster.HitChance)
            {
                // miss by Evade 
                await dtarget.ChangeMorale(1);
            }

            return 0; // Missed attack
        }

        // Calculate base damage
        float baseDamage = RandomRange(caster.DamageRange);

        var modifiers = G.interactor.FindAll<IDamageModifier>();
        foreach (var modifier in modifiers)
        {
            baseDamage = modifier.ModifyDamage(dcaster, dtarget, baseDamage);
        }

        // Apply monster's damage reduction
        baseDamage -= target.DamageReduction;

        // Apply monster's blockage (percentage reduction)
        baseDamage *= (1 - target.Blockage);

        await dcaster.ChangeMorale(1);

        // Ensure damage is not negative
        return Mathf.Max(baseDamage, 0);
    }

    public static float RandomRange(Vector2 range)
    {
        return Random.Range(range.x, range.y);
    }

    public void OnHeroFled(DungeonHero hero)
    {
        var remaining = remainingHeroes.Count(a => a.IsParticipating());
        var moraleChange = remaining switch
        {
            1 => -8,
            2 => -5,
            3 => -3,
            4 => -1,
            _ => 0
        };

        foreach (var h in remainingHeroes.OfType<DungeonHero>().Where(a => a.IsParticipating() && a != hero))
        {
            h.ChangeMorale(moraleChange).Forget();
        }
    }

    public void OnHeroDied(DungeonHero dungeonHero)
    {
        var deceasedHero = AddDeceasedHero(dungeonHero.hero);
        G.state.heroes.Remove(dungeonHero.hero); //TODO maybe check for id to remove?

        foreach (var h in remainingHeroes.OfType<DungeonHero>().Where(a => a.IsParticipating()))
        {
            h.hero.WitnessDeath(deceasedHero);
            h.ChangeMorale(-20).Forget();
        }
    }

    public static DeceasedHero AddDeceasedHero(Hero hero)
    {
        var deceasedHero = new DeceasedHero()
        {
            name = hero.name,
            tombPlace = G.state.deceasedHeroes.Count,
        };

        G.state.deceasedHeroes.Add(hero);

        return deceasedHero;
    }
}