using _Project.Data.Items;
using _Project.Data.Monsters;
using _Project.Source.Dungeon.Battle;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.VFX;

namespace _Project.Data
{
    public abstract class BaseHeroClass : CMSEntity
    {
        public BaseHeroClass()
        {
            Define<TagLevelProgression>();
        }
    }

    public class Tank : BaseHeroClass
    {
        public Tank()
        {
            Define<TagClass>().loc = "Tank";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/knight");
            Define<TagClass>().line = 3;
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Tank".Load<DungeonHero>();
            Define<TagMeleeAttack>();
        }
    }

    public class Ranger : CMSEntity
    {
        public Ranger()
        {
            Define<TagClass>().loc = "Ranger";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/warden");
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Ranger".Load<DungeonHero>();
            Define<TagRangedAttack>();
        }
    }

    public class Barbarian : BaseHeroClass
    {
        public Barbarian()
        {
            Define<TagClass>().loc = "Barbarian";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/wildling");
            Define<TagClass>().line = 3;
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Barbarian".Load<DungeonHero>();
            Define<TagMeleeAttack>();
        }
    }

    public class Healer : BaseHeroClass
    {
        public Healer()
        {
            Define<TagClass>().loc = "Healer";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/mender");
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Healer".Load<DungeonHero>();
            Define<TagHealAttack>().healEffect = "VFX/vfx_Healing".Load<AutoDestroyVFX>();
        }
    }

    public class Mage : BaseHeroClass
    {
        public Mage()
        {
            Define<TagClass>().loc = "Mage";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/savant");
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Mage".Load<DungeonHero>();
            Define<TagAoeAttack>().effectPerUnitHit = "VFX/vfx_VerticalBeam".Load<AutoDestroyVFX>();
        }
    }

    public class Captain : CMSEntity
    {
        public Captain()
        {
            Define<TagClass>().loc = "Captain";
            Define<TagClass>().icon = SpriteUtil.Load("Art/Icons/captain");
            Define<TagClass>().line = 2;
            Define<TagHeroPrefab>().prefab = "Prefabs/Heroes/Captain".Load<DungeonHero>();
            Define<TagMeleeAttack>();
        }
    }
}