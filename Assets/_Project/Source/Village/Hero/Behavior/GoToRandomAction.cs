using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Source.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(
        name: "Navigate To Random Location",
        description: "Navigates a GameObject towards another GameObject's random child using NavMeshAgent." +
                     "\nIf NavMeshAgent is not available on the [Agent] or its children, moves the Agent using its transform.",
        story: "[Agent] navigates to [Target]",
        category: "Action/Navigation",
        id: "navigate_to_random")]
    public class GoToRandomAction : GoToAction
    {
        protected override GameObject target => _target ??=
            Target.Value.transform
                .GetChild(Random.Range(0, Target.Value.transform.childCount))
                .gameObject;
    }
}