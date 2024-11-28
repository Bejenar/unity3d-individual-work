using System;
using Cysharp.Threading.Tasks;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Jump", story: "[Agent] is jumping", category: "Action",
        id: "jump_action")]
    public class JumpAction : VillagerAction
    {
        [SerializeReference]
        public BlackboardVariable<int> Times = new();

        [SerializeReference]
        public BlackboardVariable<int> Force = new();

        private readonly int jumpHash = Animator.StringToHash("Jump");

        protected override Status OnStart()
        {
            base.OnStart();

            Jump(Times).Forget();

            return Status.Running;
        }

        public async UniTaskVoid Jump(int times)
        {
            hero.Agent.enabled = false;
            // hero.rb.isKinematic = false;
            
            // TODO multiple jumping is not working
            for (int i = 0; i < 1; i++)
            {
                await Jump();
            }

            hero.Agent.enabled = true;
            // hero.rb.isKinematic = true;
            status = Status.Success;
        }

        public async UniTask Jump()
        {
            Debug.Log("Jump");
            hero.animator.CrossFade(jumpHash, 0.1f);

            // dynamic wait time
            await UniTask.WaitForSeconds(2.2f);
        }
    }
}