using Unity.Behavior;
using UnityEngine;

namespace _Project.Source.Behavior
{
    public abstract class VillagerAction : Action, IPriority
    {
        [SerializeReference]
        public BlackboardVariable<int> priority = new();
        
        [SerializeReference]
        public BlackboardVariable<VillageHero> Agent;

        protected Status status = Status.Running;
        protected VillageHero hero;

        protected override Status OnStart()
        {
            hero = Agent.Value;
            status = Status.Running;
            return base.OnStart();
        }
        
        protected override Status OnUpdate()
        {
            return status;
        }

        public int Priority => priority.Value;
    }

    public interface IPriority
    {
        int Priority { get; }
    }
}