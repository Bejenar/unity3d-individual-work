using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _Project.Source
{
    [Serializable]
    public class GameState
    {
        public List<Hero> heroes = new List<Hero>();

        public int smithyTier = 0;
        public int alchemistTier = 0;
        
        public int dungeonTier = 1;
        
        public CMSEntity selectedDungeon = null;
        public int waveIndex = 0;
        public bool isJustFromDungeon = false;
        
        public int maxUnits = 5;
        public List<Hero> selectedHeroes = new List<Hero>();
        public List<Hero> deceasedHeroes = new List<Hero>();
        
        public bool canSummonToday = true;
        public bool isFirstSummon = true;
        public int gold = 100;
    }
}