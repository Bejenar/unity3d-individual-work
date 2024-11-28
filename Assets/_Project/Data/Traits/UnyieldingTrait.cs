using _Project.Data.Items;
using _Project.Source;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Data.Traits
{
    public class UnyieldingTrait : CMSEntity
    {
        public UnyieldingTrait()
        {
            Define<TagTraitView>().name = "Unyielding";
            Define<TagUnyielding>();
        }
    }

    public class TagUnyielding : EntityComponentDefinition
    {
    }
}