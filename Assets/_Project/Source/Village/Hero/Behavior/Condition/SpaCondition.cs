using System;
using _Project.Source;
using Unity.Behavior;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Can Spa", story: "[Hero] can spa", category: "Conditions", id: "spa_condition")]
public partial class SpaCondition : Condition
{
    [SerializeReference]
    public BlackboardVariable<VillageHero> Hero;
    
    public override bool IsTrue()
    {
        if (Hero.Value.hero.sanity < 50)
        {
            return true;
        }
        
        return Random.value < 0.1f;
    }
}
