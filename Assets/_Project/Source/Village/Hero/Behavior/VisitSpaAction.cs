using System;
using Cysharp.Threading.Tasks;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Visit Spa", story: "[Agent] is visiting spa", category: "Action", id: "spa_action")]
    public class VisitSpaAction : VillagerAction
    {
        protected override Status OnStart()
        {
            base.OnStart();

            TakeBath().Forget();

            return Status.Running;
        }

        private async UniTask TakeBath()
        {
            /*
             * 	hero.lock_in_place = true
				var random_position: Vector2 = random_inside_unit_circle() * 7
				random_position.x *= 1.3
				hero.position = Data.get_location("spa_inside") + random_position
				hero.set_in_water(true)
				hero.play_spa_sfx()
				var wandering = randi_range(6, 20)
				hero.visual.spa_wander(wandering)
				await HeroActionUtils.wait_time(wandering * 2.0, hero)
				if aborted: return 
				hero.data.sanity = min(100, hero.data.sanity + wandering)

				hero.position = Data.get_location("spa")
				hero.lock_in_place = false

             */
            // Debug.Log("Visiting spa...");
            await UniTask.Delay(1000);
            
            int wandering = Random.Range(6, 20);
            hero.hero.sanity = Mathf.Min(100, hero.hero.sanity + wandering);
            // Debug.Log("Sanity: " + hero.hero.sanity);
            status = Status.Success;
        }

        /**
         * 	hero.set_in_water(false)
			hero.visual.cancel_spa_wander()
			hero.lock_in_place = false
         */
        protected override void OnEnd()
        {
        }
    }
}