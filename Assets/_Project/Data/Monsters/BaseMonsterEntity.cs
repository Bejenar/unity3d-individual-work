using _Project.Data.Items;
using _Project.Source.Dungeon.Battle;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Data.Monsters
{
    public abstract class BaseMonsterEntity : CMSEntity
    {
    }

    public class TagPrefab<T> : EntityComponentDefinition where T : MonoBehaviour
    {
        public T prefab;
    }

    public class TagHeroPrefab : TagPrefab<DungeonHero>
    {
    }

    public class TagMonsterPrefab : TagPrefab<DungeonMonster>
    {
    }

    public class TagCoinDrop : EntityComponentDefinition
    {
        public int coins;
    }

    public class TagPosition : EntityComponentDefinition
    {
        public int column;
    }

    public class TagBaseStats : EntityComponentDefinition
    {
        public int maxHealth;
        public Vector2 damageRange;
        public float evasion;
        public float damageReduction;
        public float hitChance;
        public float critChance;
        public float blockage;
        public float gutsAmount;
    }


    public class Mushroom : BaseMonsterEntity
    {
        public Mushroom()
        {
            Define<TagClass>().loc = "mushroom";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Mushroom".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 2;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 3;
            Define<TagBaseStats>().damageRange = new Vector2(1, 1);
            Define<TagBaseStats>().evasion = 0.0f;
            Define<TagBaseStats>().damageReduction = 0.0f;
            Define<TagBaseStats>().hitChance = 0.9f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.0f;
            Define<TagBaseStats>().gutsAmount = 0.0f;
            Define<TagMeleeAttack>();
        }
    }

    public class Wolf : BaseMonsterEntity
    {
        public Wolf()
        {
            Define<TagClass>().loc = "wolf";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Wolf".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 3;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 6;
            Define<TagBaseStats>().damageRange = new Vector2(2, 3);
            Define<TagBaseStats>().evasion = 0.2f;
            Define<TagBaseStats>().hitChance = 0.8f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.0f;
            Define<TagBaseStats>().gutsAmount = 5.0f;
            Define<TagMeleeAttack>();
        }
    }

    public class Wendigo : BaseMonsterEntity
    {
        public Wendigo()
        {
            Define<TagClass>().loc = "wendigo";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Wendigo".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 50;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 40;
            Define<TagBaseStats>().damageRange = new Vector2(3, 8);
            Define<TagBaseStats>().evasion = 0.1f;
            Define<TagBaseStats>().hitChance = 0.8f;
            Define<TagBaseStats>().critChance = 0.1f;
            Define<TagBaseStats>().blockage = 0.0f;
            Define<TagBaseStats>().gutsAmount = 8.0f;
            Define<TagMeleeAttack>();
        }
    }

    public class Skeleton : BaseMonsterEntity
    {
        public Skeleton()
        {
            Define<TagClass>().loc = "skeleton";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Skeleton".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 6;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 15;
            Define<TagBaseStats>().damageRange = new Vector2(2, 3);
            Define<TagBaseStats>().evasion = 0.0f;
            Define<TagBaseStats>().damageReduction = 1.0f;
            Define<TagBaseStats>().hitChance = 0.8f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.7f;
            Define<TagBaseStats>().gutsAmount = 2.0f;
            Define<TagMeleeAttack>();
        }
    }

    public class SkeletonArcher : BaseMonsterEntity
    {
        public SkeletonArcher()
        {
            Define<TagClass>().loc = "Skeleton archer";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/SkeletonArcher".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 6;
            Define<TagPosition>().column = 1;
            Define<TagBaseStats>().maxHealth = 6;
            Define<TagBaseStats>().damageRange = new Vector2(3, 6);
            Define<TagBaseStats>().evasion = 0.2f;
            Define<TagBaseStats>().hitChance = 0.8f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.5f;
            Define<TagBaseStats>().gutsAmount = 2.0f;
            Define<TagRangedAttack>();
        }
    }

    public class SkeletonMage : BaseMonsterEntity
    {
        public SkeletonMage()
        {
            Define<TagClass>().loc = "Skeleton mage";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/SkeletonMage".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 14;
            Define<TagPosition>().column = 2;
            Define<TagBaseStats>().maxHealth = 8;
            Define<TagBaseStats>().damageRange = new Vector2(4, 4);
            Define<TagBaseStats>().evasion = 0.3f;
            Define<TagBaseStats>().damageReduction = 1.0f;
            Define<TagBaseStats>().hitChance = 1.0f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.0f;
            Define<TagBaseStats>().gutsAmount = 2.0f;
            Define<TagHealAttack>().healEffect = "VFX/vfx_Healing".Load<AutoDestroyVFX>();
        }
    }

    public class SkeletonKing : BaseMonsterEntity
    {
        public SkeletonKing()
        {
            Define<TagClass>().loc = "Skeleton king";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/SkeletonKing".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 120;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 50;
            Define<TagBaseStats>().damageRange = new Vector2(5, 7);
            Define<TagBaseStats>().evasion = 0.0f;
            Define<TagBaseStats>().hitChance = 1.0f;
            Define<TagBaseStats>().critChance = 0.2f;
            Define<TagBaseStats>().blockage = 0.7f;
            Define<TagBaseStats>().gutsAmount = 10.0f;
            Define<TagRangedAttack>();
        }
    }

    public class Brute : BaseMonsterEntity
    {
        public Brute()
        {
            Define<TagClass>().loc = "Brute";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Brute".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 20;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 40;
            Define<TagBaseStats>().damageRange = new Vector2(3, 5);
            Define<TagBaseStats>().evasion = 0.0f;
            Define<TagBaseStats>().hitChance = 0.9f;
            Define<TagBaseStats>().critChance = 0.1f;
            Define<TagBaseStats>().blockage = 0.8f;
            // Define<TagBaseStats>().blockage = 0.1f;
            Define<TagBaseStats>().gutsAmount = 0.0f;
            Define<TagMeleeAttack>();
        }
    }

    public class Succubus : BaseMonsterEntity
    {
        public Succubus()
        {
            Define<TagClass>().loc = "Succubus";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Succubus".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 20;
            Define<TagPosition>().column = 2;
            Define<TagBaseStats>().maxHealth = 15;
            Define<TagBaseStats>().damageRange = new Vector2(3, 6);
            Define<TagBaseStats>().evasion = 0.5f;
            Define<TagBaseStats>().hitChance = 1.0f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.5f;
            Define<TagBaseStats>().gutsAmount = 2.0f;
            Define<TagAoeAttack>().effectPerUnitHit = "VFX/vfx_VerticalBeam2".Load<AutoDestroyVFX>();
            Define<TagAoeAttack>().attackType = RangedAttackType.Spawn;
        }
    }

    public class Demon : BaseMonsterEntity
    {
        public Demon()
        {
            Define<TagClass>().loc = "Demon";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Demon".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 20;
            Define<TagPosition>().column = 1;
            Define<TagBaseStats>().maxHealth = 6;
            Define<TagBaseStats>().damageRange = new Vector2(4, 6);
            Define<TagBaseStats>().evasion = 0.3f;
            Define<TagBaseStats>().hitChance = 1.4f;
            Define<TagBaseStats>().critChance = 0.1f;
            Define<TagBaseStats>().blockage = 0.5f;
            Define<TagBaseStats>().gutsAmount = 3.0f;
            Define<TagRangedAttack>();
        }
    }

    public class Beholder : BaseMonsterEntity
    {
        public Beholder()
        {
            Define<TagClass>().loc = "Beholder";
            Define<TagMonsterPrefab>().prefab = "Prefabs/Monsters/Beholder".Load<DungeonMonster>();
            Define<TagCoinDrop>().coins = 500;
            Define<TagPosition>().column = 0;
            Define<TagBaseStats>().maxHealth = 100;
            Define<TagBaseStats>().damageRange = new Vector2(5, 10);
            Define<TagBaseStats>().evasion = 0.0f;
            Define<TagBaseStats>().hitChance = 1.1f;
            Define<TagBaseStats>().critChance = 0.0f;
            Define<TagBaseStats>().blockage = 0.5f;
            Define<TagBaseStats>().gutsAmount = 10.0f;
            Define<TagAoeAttack>().effectPerUnitHit = "VFX/vfx_FireBall".Load<AutoDestroyVFX>();
            Define<TagAoeAttack>().attackType = RangedAttackType.Projectile;
        }
    }

    public interface IAttackEffectBehavior
    {
        public UniTask Execute(DungeonCharacter actor, DungeonCharacter target, TagAoeAttack tag);
    }

    public class LaunchAttackInteraction : BaseInteraction, IAttackEffectBehavior
    {
        public async UniTask Execute(DungeonCharacter actor, DungeonCharacter target, TagAoeAttack tag)
        {
            if (tag.attackType != RangedAttackType.Projectile) return;

            var vfx = Object.Instantiate(tag.effectPerUnitHit, actor.head.position, Quaternion.identity);
            // await vfx.gameObject.transform.DOMove(target.transform.position, vfx.duration);
            await vfx.gameObject.transform.DOPath(
                new[]
                {
                    actor.head.position, (actor.head.position + target.transform.position) / 2,
                    target.transform.position
                }, vfx.duration, PathType.CatmullRom);
        }
    }

    public class SpawnAttackInteraction : BaseInteraction, IAttackEffectBehavior
    {
        public async UniTask Execute(DungeonCharacter actor, DungeonCharacter target, TagAoeAttack tag)
        {
            if (tag.attackType != RangedAttackType.Spawn) return;

            var vfx = Object.Instantiate(tag.effectPerUnitHit, target.transform.position, Quaternion.identity);
            await UniTask.WaitForSeconds(vfx.duration);
        }
    }
}