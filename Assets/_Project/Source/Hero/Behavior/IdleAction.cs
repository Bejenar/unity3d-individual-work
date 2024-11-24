using System;
using _Project.Data;
using Cysharp.Threading.Tasks;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Random = UnityEngine.Random;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Idle", story: "[Agent] is doing nothing", category: "Action",
        id: "idle_action")]
    public class IdleAction : VillagerAction
    {
        [SerializeReference]
        public BlackboardVariable<float> Time = new();
        
        private readonly int idleHash = Animator.StringToHash("Idle");
        
        protected override Status OnStart()
        {
            base.OnStart();
            // hero.animator.CrossFade(idleHash, 0.2f);
            
            WaitFor(Time.Value).Forget();
            
            return Status.Running;
        }

        private async UniTaskVoid WaitFor(float timeInSeconds)
        {
            // hero.animator.CrossFade(idleHash, 0.1f);
            await UniTask.WaitForSeconds(timeInSeconds);
            status = Status.Success;
        }
    }
}