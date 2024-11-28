using System.Collections.Generic;
using System.Linq;
using _Project.Data;
using _Project.Data.Items;
using _Project.Data.Monsters;
using _Project.Data.Traits;
using _Project.Source.Dungeon.Battle;
using _Project.Source.Village.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityUtils;
using Random = UnityEngine.Random;

namespace _Project.Source.Scenes
{
    public enum Phase
    {
        BEGIN,
        FIGHTING,
        LOOTING,
        FINISHED
    }

    public class Dungeon : MonoBehaviour
    {
        public Phase phase = Phase.BEGIN;

        [FormerlySerializedAs("dungeonHud")]
        public DungeonHUD hud;

        private Party<DungeonHero> heroes = new Party<DungeonHero>();
        private Party<DungeonMonster> monsters = new Party<DungeonMonster>();
        public FieldData fieldData;

        public Transform[] heroPositions;
        public Transform[] monsterPositions;

        public bool isRunning;

        private void Start()
        {
            G.dungeon = this;
            G.fader.FadeOut();

            isRunning = true;
            ProcessBattle().Forget();
        }

        public async UniTask ProcessBattle()
        {
            while (isRunning)
            {
                switch (phase)
                {
                    case Phase.BEGIN:
                        // Time.timeScale = 4;
                        await BeginPhase();
                        break;
                    case Phase.FIGHTING:
                        await FightingPhase();
                        break;
                    case Phase.LOOTING:
                        await Looting();
                        break;
                    case Phase.FINISHED:
                        Time.timeScale = 1;
                        await FinishedPhase();
                        return;
                }
            }
        }

        private async UniTask BeginPhase()
        {
            Debug.Log("Processing battle");
            var selected = G.state.selectedHeroes;
            if (selected.Count == 0)
            {
                // debug
                selected.Add(HeroSummoning.CreateHero(CMS.Get<Tank>()));
                selected[0].AddTrait<UnyieldingTrait>();
                // selected.Add(HeroSummoning.CreateHero(CMS.Get<Barbarian>()));
                selected.Add(HeroSummoning.CreateHero(CMS.Get<Healer>()));
                selected.Add(HeroSummoning.CreateHero(CMS.Get<Mage>()));

                G.state.selectedDungeon = CMS.Get<Level1>();
            }

            for (int i = 0; i < selected.Count; i++)
            {
                if (selected[i].fled || selected[i].died)
                {
                    continue;
                }
                
                if (G.state.waveIndex == 0)
                {
                    selected[i].UpdateStats();
                }

                heroes.members.Add(await SummonHero(selected[i], heroPositions[i]));
            }

            hud.InitHUD(heroes.members);

            var wave = GetCurrentWave();
            for (int i = 0; i < wave.Count; i++)
            {
                monsters.members.Add(await SummonMonster(wave[i], monsterPositions[i]));
            }

            heroes.members.ForEach(hero => { hero.DrawWeapon(); });

            await UniTask.WaitForSeconds(2f);

            Debug.Log("Battle started");
            fieldData = new FieldData();
            fieldData.heroParty = heroes;
            fieldData.monsterParty = monsters;

            // animate heroes and monsters
            // show battle UI
            phase = Phase.FIGHTING;
        }

        private async UniTask FightingPhase()
        {
            // Debug.Log("Fighting phase " + fieldData);
            if (MobPartyIsDead())
            {
                Debug.Log("Monster party is dead");
                phase = Phase.LOOTING;
                return;
            }

            if (HeroPartyIsDead())
            {
                Debug.Log("Hero party is dead");
                phase = Phase.FINISHED;
                return;
            }

            if (!heroes.CanAttack())
            {
                Debug.Log("Heroes can't attack");
                await heroes.ChangeMorale(fieldData, -5);
            }

            var actor = fieldData.PopActor();

            var all = G.interactor.FindAll<IOnAttack>();
            foreach (var onAttack in all)
            {
                await onAttack.OnAttack(fieldData, actor);
            }
            
            // await UniTask.WhenAll(fieldData.actors.Select(async character => await character.AfterMoraleHit())
            //     .Append(actor.AfterMoraleHit()).ToArray());
        }

        private async UniTask Looting()
        {
            Debug.Log("Looting phase");
            await heroes.ChangeMorale(fieldData, 20);
            // loot coins
            var totalGold = fieldData.monsterParty.members
                .Sum(dungeonMonster => dungeonMonster.monster.model.Get<TagCoinDrop>().coins);

            await UniTask.WaitForSeconds(1f);
            var participating = heroes.GetParticipating();
            var timeStep = 1f / totalGold;
            while (totalGold > 0)
            {
                if (participating.Count == 0)
                {
                    participating = heroes.GetParticipating();
                }

                var randomHero = participating.GetRandom();
                participating.Remove(randomHero);

                var gold = Mathf.CeilToInt(Mathf.Clamp(Mathf.Round(totalGold * 0.1f), 1, totalGold));
                randomHero.AddGold(gold);
                hud.ShowMoneyText(gold, randomHero.transform.position);
                await UniTask.WaitForSeconds(timeStep);
                totalGold -= gold;
            }

            await UniTask.WaitForSeconds(0.5f);
            foreach (var hero in heroes.GetParticipating())
            {
                hero.animator.CrossFade(DungeonCharacter.Running, 0.2f);
            }
            await UniTask.WaitForSeconds(0.5f);

            // if next battle available, load new scene and start new battle
            if (G.state.waveIndex < G.state.selectedDungeon.Get<TagListChallenges>().all.Count - 1)
            {
                G.state.waveIndex++;
                isRunning = false;
                G.fader.FadeIn();
                await UniTask.WaitForSeconds(1f);
                await SceneManager.LoadSceneAsync("Dungeon");
                return;
            }

            phase = Phase.FINISHED;
        }

        private async UniTask FinishedPhase()
        {
            isRunning = false;
            G.state.isJustFromDungeon = true;

            G.fader.FadeIn();
            await UniTask.WaitForSeconds(1);
            await SceneManager.LoadSceneAsync("Village");
        }

        private bool MobPartyIsDead()
        {
            return fieldData.monsterParty.GetParticipating().Count == 0;
        }

        private bool HeroPartyIsDead()
        {
            return fieldData.heroParty.GetParticipating().Count == 0;
        }

        private List<Monster> GetCurrentWave()
        {
            var dungeon = G.state.selectedDungeon;
            var wave = CMS.Get<CMSEntity>(dungeon.Get<TagListChallenges>().all[G.state.waveIndex]);

            return wave.Get<TagMobGroup>().mobGroup
                .Select(CMS.Get<BaseMonsterEntity>)
                .Select(model => new Monster(model))
                .ToList();
        }

        public async UniTask<DungeonHero> SummonHero(Hero hero, Transform parent)
        {
            var summonHero = Instantiate(hero.model.Get<TagHeroPrefab>().prefab, parent);
            summonHero.transform.localPosition = Random.insideUnitSphere.With(y: 0) * 0.1f;
            summonHero.Init(hero);

            await UniTask.CompletedTask;
            return summonHero;
        }

        public async UniTask<DungeonMonster> SummonMonster(Monster monster, Transform parent)
        {
            await UniTask.WaitForEndOfFrame();
            var summonMonster = Instantiate(monster.model.Get<TagMonsterPrefab>().prefab, parent);
            summonMonster.transform.localPosition = Random.insideUnitSphere.With(y: 0) * 0.1f;
            summonMonster.Init(monster);
            return summonMonster;
        }
    }
}