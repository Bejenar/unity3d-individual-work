using System;
using _Project.Source.Village;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace _Project.Source
{
    public class VillageHero : SelectableBehaviour
    {
        public Transform head;
        
        public Hero hero;
        public BehaviorGraphAgent behaviorAgent;
        public Rigidbody rb;
        [FormerlySerializedAs("navMeshAgent")]
        public NavMeshAgent Agent;
        public Animator animator;

        public LayerMask groundLayer;
        public Transform groundCheck;
        public bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.2f, groundLayer);

        public bool IsCandidate => State == VillagerState.WAITING_FOR_RECRUITMENT;

        public VillagerState State
        {
            get => behaviorAgent.GetVariable("VillagerState", out BlackboardVariable<VillagerState> state)
                ? state
                : null;

            set => behaviorAgent.SetVariableValue("VillagerState", value);
        }

        public Transform InitParent { get; protected set; }

        public override void Start()
        {
            base.Start();
            
            InitParent = transform.parent;
            
            animator.applyRootMotion = true;
            Agent.updatePosition = false;
            Agent.updateRotation = true;
        }

        private void OnAnimatorMove()
        {
            var rootPos = animator.rootPosition;
            if (Agent.enabled)
                rootPos.y = Agent.nextPosition.y;
            transform.position = rootPos;
            Agent.nextPosition = rootPos;
        }

        private void Update()
        {
            // SynchronizeAnimatorAndAgent();
        }
        
        private Vector2 Velocity;
        private Vector2 SmoothDeltaPosition;

        private void SynchronizeAnimatorAndAgent()
        {
            if (!Agent.enabled) return;
            
            Vector3 worldDeltaPosition = Agent.nextPosition - transform.position;
            worldDeltaPosition.y = 0;
            
            float dx = Vector3.Dot(transform.right, worldDeltaPosition);
            float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
            Vector2 deltaPosition = new Vector2(dx, dy);
            
            float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
            SmoothDeltaPosition = Vector2.Lerp(SmoothDeltaPosition, deltaPosition, smooth);
            
            Velocity = SmoothDeltaPosition / Time.deltaTime;
            if (Agent.hasPath && Agent.remainingDistance <= Agent.stoppingDistance)
            {
                Velocity = Vector2.Lerp(
                    Vector2.zero, 
                    Velocity, 
                    Agent.remainingDistance / Agent.stoppingDistance
                );
            }
            
            float deltaMagnitude = worldDeltaPosition.magnitude;
            if (deltaMagnitude > Agent.radius / 2f)
            {
                transform.position = Vector3.Lerp(
                    animator.rootPosition,
                    Agent.nextPosition,
                    smooth
                );
            }
        }

        public void Init(Hero hero)
        {
            this.hero = hero;
            Debug.Log($"{hero.name} is of type {hero.model.GetType().Name}");

            behaviorAgent.SetVariableValue("entrance", G.main.entrance);
            behaviorAgent.SetVariableValue("partyMeetup", G.main.partyMeetup);
            behaviorAgent.SetVariableValue("randomPlaces", G.main.randomPlaces);
            behaviorAgent.SetVariableValue("blacksmith", G.main.blacksmith.gameObject);
            behaviorAgent.SetVariableValue("alchemist", G.main.alchemist.gameObject);
            behaviorAgent.SetVariableValue("spa", G.main.spa.gameObject);
            
            foreach (var r in renderers)
            {
                if (r.material.name.Contains(StaticData.HairMatName))
                {
                    var material = r.material;
                    material.SetColor(StaticData.DarkColor, hero.hairColor);
                    material.SetColor(StaticData.LitColor, hero.hairColor);
                }
            }
        }

        public void ForceState(VillagerState state)
        {
            State = state;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (IsCandidate)
            {
                G.ui.recruitTooltipView.ShowTooltip(this, Input.mousePosition);
                return;
            }

            G.ui.tooltipView.ShowTooltip(hero, Input.mousePosition, true);
        }
    }
}