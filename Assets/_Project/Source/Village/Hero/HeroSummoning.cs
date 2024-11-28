using _Project.Data;
using _Project.Data.Traits;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Source
{
    public class HeroSummoning
    {
        public static void RollInitialTraits(Hero hero)
        {
            if (Random.value < 0.1)
                hero.AddTrait<CurseNoLuckTrait>();
            
            if (Random.value < 0.1)
                hero.AddTrait<CowardTrait>();
            
            if (Random.value < 0.1)
                hero.AddTrait<StubbornTrait>();
            
            if (Random.value < 0.1)
                hero.AddTrait<UnyieldingTrait>();
            
            if (Random.value < 0.1)
                hero.AddTrait<RevengefulTrait>();
        }

        public static void RollHairColor(Hero hero)
        {
            hero.hairColor = new Color(Random.value, Random.value, Random.value);
        }
        
        public static Hero CreateHero(BaseHeroClass heroClass = null)
        {
            if (heroClass == null)
                heroClass = CMS.GetAll<BaseHeroClass>().GetRandom();
            
            var hero = new Hero(heroClass);
            RollInitialTraits(hero);
            RollHairColor(hero);
            return hero;
        }
    }
}