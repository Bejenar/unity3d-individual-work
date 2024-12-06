using _Project.Source;
using UnityEngine;

namespace _Project.Data
{
    public class TagClass : EntityComponentDefinition
    {
        public Sprite icon;
        public string loc;
        public int line = 1;
        public VillageHero villagePrefab;
    }
}