using System;
using System.Linq;
using _Project.Data.Traits;
using _Project.Source;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[Condition(name: "Can Visit Tomb", story: "[Hero] can visit [Tomb] of Dead", category: "Conditions",
    id: "tomb_condition")]
public partial class TombCondition : Condition
{
    [SerializeReference]
    public BlackboardVariable<VillageHero> Hero;

    [SerializeReference]
    public BlackboardVariable<GameObject> Tomb;

    public override bool IsTrue()
    {
        if (!Hero.Value.hero.Traits.IsWithState<TagWitnessedDeath, WitnessedDeathState>(out var s)) return false;
        
        Tomb.Value = G.cemetry.GetTombObject(s.deceasedHeroes.First().tombPlace);
        return Random.value < 0.25f;
    }
}