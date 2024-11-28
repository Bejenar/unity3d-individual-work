using System;
using System.Linq;
using _Project.Data.Traits;
using Cysharp.Threading.Tasks;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Visit Tomb", story: "[Agent] is visiting [Dead]'s tomb", category: "Action",
        id: "tomb_action")]
    public class VisitTombAction : VillagerAction
    {
        private static readonly string[] LINES =
        {
            "I miss you {0}.",
            "I'm sorry {0}.",
            "It's not the same without you {0}.",
            "{0}, I'll avenge you."
        };
        
        private DeceasedHero deadHeroToVisit;

        protected override Status OnStart()
        {
            if (!Agent.Value.hero.Traits.IsWithState<TagWitnessedDeath, WitnessedDeathState>(out var s)) return Status.Failure;

            deadHeroToVisit = s.deceasedHeroes.First();
            base.OnStart();

            VisitTomb().Forget();

            return Status.Running;
        }

        private async UniTask VisitTomb()
        {
            Debug.Log("Visiting tomb of... " + deadHeroToVisit.name);
            await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(3, 7)));
            Debug.Log(GetRandomLine());
            await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(3, 15)));
            status = Status.Success;
        }

        protected override void OnEnd()
        {
        }

        private String GetRandomLine()
        {
            return string.Format(LINES[Random.Range(0, LINES.Length)], deadHeroToVisit.name);
        }
    }
}