using _Project.Data.Items;
using _Project.Data.Monsters;

    public class Level3 : CMSEntity
    {
        public Level3()
        {
            Define<TagListChallenges>().all.Add(E.Id<Wave3_1>());
            Define<TagListChallenges>().all.Add(E.Id<Wave3_2>());
            Define<TagListChallenges>().all.Add(E.Id<Wave3_3>());
            Define<TagListChallenges>().all.Add(E.Id<Wave3_4>());
            Define<TagListChallenges>().all.Add(E.Id<Wave3_1Boss>());
            Define<TagTier>().tier = 3;
            Define<TagLevelView>().sprite = SpriteUtil.Load("Art/dungIcon3");
            Define<TagLevelView>().dungeonPrefab = GameResources.Prefabs.Dungeon.DungeonPrefab__3_;
        }
    }

    public class Wave3_1 : CMSEntity
    {
        public Wave3_1()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Demon>());
        }
    }

    public class Wave3_2 : CMSEntity
    {
        public Wave3_2()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Demon>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Demon>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Demon>());
        }
    }

    public class Wave3_3 : CMSEntity
    {
        public Wave3_3()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Succubus>());
        }
    }

    public class Wave3_4 : CMSEntity
    {
        public Wave3_4()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Succubus>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Succubus>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
        }
    }

    public class Wave3_1Boss : CMSEntity
    {
        public Wave3_1Boss()
        {
            Define<TagMobGroup>().mobGroup.Add(E.Id<Beholder>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
            Define<TagMobGroup>().mobGroup.Add(E.Id<Brute>());
        }
    }