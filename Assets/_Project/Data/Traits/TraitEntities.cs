using System;
using System.Collections.Generic;
using _Project.Data.Items;
using _Project.Source;
using UnityEngine;

namespace _Project.Data.Traits
{
    public class TagTraitView : EntityComponentDefinition
    {
        public string name;
    }
    
    public class CowardTrait : CMSEntity
    {
        public CowardTrait()
        {
            Define<TagTraitView>().name = "Coward";
            Define<TagStatsOverrideBuff>().moraleDamageMultiplier = 1.333f;
        }
    }
    
    public class StubbornTrait : CMSEntity
    {
        public StubbornTrait()
        {
            Define<TagTraitView>().name = "Stubborn";
            Define<TagStatsOverrideBuff>().moraleDamageMultiplier = 0.8f;
        }
    }


    public class WitnessedDeathTrait : CMSEntity
    {
        public WitnessedDeathTrait()
        {
            Define<TagTraitView>().name = "Witnessed Death";
            Define<TagWitnessedDeath>();
        }
    }
    
    public class WitnessedDeathNowTrait : CMSEntity
    {
        public WitnessedDeathNowTrait()
        {
            Define<TagTraitView>().name = "Witnessed Death";
            Define<TagWitnessedDeathNow>();
        }
    }
    
    [Serializable]
    public class WitnessedDeathState : StateComponent
    {
        public List<DeceasedHero> deceasedHeroes = new();
    }
    
    public class TagWitnessedDeath : EntityComponentDefinition
    {
        
    }
    
    public class TagWitnessedDeathNow : EntityComponentDefinition
    {
        
    }
    
}