using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(
        name: "(p) Navigate To Location",
        description: "Navigates a GameObject towards another GameObject using NavMeshAgent." +
                     "\nIf NavMeshAgent is not available on the [Agent] or its children, moves the Agent using its transform.",
        story: "[Agent] navigates to [Target]",
        category: "Action/Navigation",
        id: "navigate_to_location")]
    public class GoToAction : VillagerAction
    {
        [SerializeReference]
        public BlackboardVariable<GameObject> Target;

        [SerializeReference]
        public BlackboardVariable<float> Speed = new BlackboardVariable<float>(1.0f);

        [SerializeReference]
        public BlackboardVariable<float> DistanceThreshold = new BlackboardVariable<float>(0.2f);

        [SerializeReference]
        public BlackboardVariable<string> AnimatorSpeedParam = new BlackboardVariable<string>("SpeedMagnitude");

        // This will only be used in movement without a navigation agent.
        [SerializeReference]
        public BlackboardVariable<float> SlowDownDistance = new BlackboardVariable<float>(1.0f);

        private NavMeshAgent m_NavMeshAgent;
        private Animator m_Animator;
        private float m_PreviousStoppingDistance;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_ColliderAdjustedTargetPosition;
        private float m_ColliderOffset;

        protected GameObject _target = null;
        protected virtual GameObject target => _target ??= Target.Value;
        
        private readonly int walkHash = Animator.StringToHash("Walk");
        private readonly int idleHash = Animator.StringToHash("Idle");

        protected override Status OnStart()
        {
            base.OnStart();
            
            if (ReferenceEquals(Agent?.Value, null) || ReferenceEquals(Target?.Value, null))
            {
                return Status.Failure;
            }

            hero.animator.CrossFade(walkHash, 0.05f);
            return Initialize();
        }

        protected override Status OnUpdate()
        {
            if (ReferenceEquals(Agent?.Value, null) || ReferenceEquals(Target, null))
            {
                return Status.Failure;
            }

            // Check if the target position has changed.
            bool boolUpdateTargetPosition = !Mathf.Approximately(m_LastTargetPosition.x, target.transform.position.x) ||
                                            !Mathf.Approximately(m_LastTargetPosition.y, target.transform.position.y) ||
                                            !Mathf.Approximately(m_LastTargetPosition.z, target.transform.position.z);
            if (boolUpdateTargetPosition)
            {
                m_LastTargetPosition = target.transform.position;
                m_ColliderAdjustedTargetPosition = GetPositionColliderAdjusted();
            }

            float distance = GetDistanceXZ();
            if (distance <= (DistanceThreshold + m_ColliderOffset))
            {
                return Status.Success;
            }

            if (m_NavMeshAgent != null)
            {
                if (boolUpdateTargetPosition)
                {
                    m_NavMeshAgent.SetDestination(m_ColliderAdjustedTargetPosition);
                }

                if (IsNavigationComplete(m_NavMeshAgent))
                {
                    return Status.Success;
                }
            }
            else
            {
                float speed = Speed;

                if (SlowDownDistance > 0.0f && distance < SlowDownDistance)
                {
                    float ratio = distance / SlowDownDistance;
                    speed = Mathf.Max(0.1f, Speed * ratio);
                }

                Vector3 agentPosition = Agent.Value.transform.position;
                Vector3 toDestination = m_ColliderAdjustedTargetPosition - agentPosition;
                toDestination.y = 0.0f;
                toDestination.Normalize();
                agentPosition += toDestination * (speed * Time.deltaTime);
                Agent.Value.transform.position = agentPosition;

                // Look at the target.
                Agent.Value.transform.forward = toDestination;
            }

            return Status.Running;
        }

        protected override void OnEnd()
        {
            if (m_Animator != null)
            {
                m_Animator.SetFloat(AnimatorSpeedParam, 0);
            }

            if (m_NavMeshAgent != null)
            {
                if (m_NavMeshAgent.isOnNavMesh)
                {
                    m_NavMeshAgent.ResetPath();
                }

                m_NavMeshAgent.stoppingDistance = m_PreviousStoppingDistance;
            }

            m_NavMeshAgent = null;
            m_Animator = null;
            _target = null;
            
            hero.animator.CrossFade(idleHash, 0.3f);
        }

        protected override void OnDeserialize()
        {
            Initialize();
        }

        private Status Initialize()
        {
            m_LastTargetPosition = target.transform.position;
            m_ColliderAdjustedTargetPosition = GetPositionColliderAdjusted();

            // Add the extents of the colliders to the stopping distance.
            m_ColliderOffset = 0.0f;
            Collider agentCollider = Agent.Value.GetComponentInChildren<Collider>();
            if (agentCollider != null)
            {
                Vector3 colliderExtents = agentCollider.bounds.extents;
                m_ColliderOffset += Mathf.Max(colliderExtents.x, colliderExtents.z);
            }

            if (GetDistanceXZ() <= (DistanceThreshold + m_ColliderOffset))
            {
                return Status.Success;
            }

            // If using animator, set speed parameter.
            m_Animator = Agent.Value.GetComponentInChildren<Animator>();
            if (m_Animator != null)
            {
                m_Animator.SetFloat(AnimatorSpeedParam, Speed);
            }

            // If using a navigation mesh, set target position for navigation mesh agent.
            m_NavMeshAgent = Agent.Value.GetComponentInChildren<NavMeshAgent>();
            if (m_NavMeshAgent != null)
            {
                if (m_NavMeshAgent.isOnNavMesh)
                {
                    m_NavMeshAgent.ResetPath();
                }

                m_NavMeshAgent.speed = Speed;
                m_PreviousStoppingDistance = m_NavMeshAgent.stoppingDistance;

                m_NavMeshAgent.stoppingDistance = DistanceThreshold + m_ColliderOffset;
                m_NavMeshAgent.SetDestination(m_ColliderAdjustedTargetPosition);
            }

            return Status.Running;
        }


        private Vector3 GetPositionColliderAdjusted()
        {
            // Collider targetCollider = target.GetComponentInChildren<Collider>();
            // if (targetCollider != null)
            // {
            //     return targetCollider.ClosestPoint(Agent.Value.transform.position);
            // }

            return target.transform.position;
        }

        private float GetDistanceXZ()
        {
            Vector3 agentPosition = new Vector3(Agent.Value.transform.position.x, m_ColliderAdjustedTargetPosition.y,
                Agent.Value.transform.position.z);
            return Vector3.Distance(agentPosition, m_ColliderAdjustedTargetPosition);
        }

        private bool IsNavigationComplete(NavMeshAgent agent)
        {
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }
    }
}