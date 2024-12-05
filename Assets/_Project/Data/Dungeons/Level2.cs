using _Project.Data.Items;
using _Project.Data.Monsters;

namespace _Project.Data.Dungeons
{
    public class Level2 : CMSEntity
    {
        public Level2()
        {
            Define<TagListChallenges>().all.Add(E.Id<Wave2_1>());
            Define<TagListChallenges>().all.Add(E.Id<Wave2_2>());
            Define<TagListChallenges>().all.Add(E.Id<Wave2_3>());
            Define<TagListChallenges>().all.Add(E.Id<Wave2_4>());
            Define<TagListChallenges>().all.Add(E.Id<Wave2_1Boss>());
            Define<TagTier>().tier = 2;
            Define<TagLevelView>();
        }
    }

    public class Wave2_1 : CMSEntity
    {
        public Wave2_1()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Skeleton>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
        }
    }

    public class Wave2_2 : CMSEntity
    {
        public Wave2_2()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Skeleton>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Skeleton>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
        }
    }

    public class Wave2_3 : CMSEntity
    {
        public Wave2_3()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Skeleton>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonMage>());
        }
    }

    public class Wave2_4 : CMSEntity
    {
        public Wave2_4()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Skeleton>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonArcher>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonMage>());
        }
    }

    public class Wave2_1Boss : CMSEntity
    {
        public Wave2_1Boss()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonKing>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonMage>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonMage>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<SkeletonMage>());
        }
    }
}