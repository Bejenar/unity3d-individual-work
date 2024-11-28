using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Behavior;
using Unity.Properties;
using Random = UnityEngine.Random;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(
        name: "Priority Sequence",
        description: "Executes branches in sorted order until one fails or all succeed.",
        category: "Flow",
        id: "priority_selector")]
    public class PrioritySequence : Composite
    {
        List<Node> sortedChildren;
        List<Node> SortedChildren => sortedChildren ??= SortChildren();
        
        protected virtual List<Node> SortChildren() => 
            Children.OrderByDescending(child => child is IPriority priorityActon ? priorityActon.Priority : 0).ToList();
        
        
        [CreateProperty] private int m_CurrentChild;

        protected override Status OnStart()
        {
            m_CurrentChild = 0;
            if (SortedChildren.Count == 0)
                return Status.Success;

            var status = StartNode(SortedChildren[0]);
            if (status == Status.Failure)
                return Status.Failure;
            if (status == Status.Success)
                return Status.Running;

            return Status.Waiting;
        }

        protected override Status OnUpdate()
        {
            var currentChild = SortedChildren[m_CurrentChild];
            Status childStatus = currentChild.CurrentStatus;
            if (childStatus == Status.Success)
            {
                if (m_CurrentChild == SortedChildren.Count-1)
                    return Status.Success;

                m_CurrentChild++;

                var status = StartNode(SortedChildren[m_CurrentChild]);
                if (status == Status.Failure)
                    return Status.Failure;
                if (status == Status.Success)
                    return Status.Running;
            }
            else if (childStatus == Status.Failure)
            {
                return Status.Failure;
            }
            return Status.Waiting;
        }

        protected override void OnEnd()
        {
            base.OnEnd();
            sortedChildren = null;
        }
    }
}