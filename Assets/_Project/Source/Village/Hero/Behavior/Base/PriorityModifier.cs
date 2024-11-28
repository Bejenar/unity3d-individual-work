using System;
using System.Collections.Generic;
using _Project.Source.Behavior;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PriorityModifier", story: "Execute with priority [priority]", category: "Flow", id: "d3b39625b3bb6ec24ebbe2360725365a")]
public partial class PriorityModifier : Modifier, IPriority
{
    [SerializeReference]
    public BlackboardVariable<int> priority = new();

    protected override Status OnStart()
    {
        if (Child == null)
        {
            return Status.Failure;
        }
            
        Status status = StartNode(Child);
        if (status == Status.Success)
            return Status.Success;
        if (status == Status.Failure)
            return Status.Failure;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        // Check the child status 
        Status status = Child.CurrentStatus;
        if (status == Status.Success)
            return Status.Success;
        if (status == Status.Failure)
            return Status.Failure;

        return Status.Running;
    }

    public int Priority => priority.Value;
}

