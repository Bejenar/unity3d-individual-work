using System.Collections.Generic;
using _Project.Data.Items;
using _Project.Data.Monsters;
using UnityEngine;

public class TagListChallenges : EntityComponentDefinition
{
    public List<string> all = new List<string>();
}

public class TagMobGroup : EntityComponentDefinition
{
    public List<string> mobGroup = new();
}

public class TagLevelView : EntityComponentDefinition
{
    public Sprite sprite;
}

public class Level1 : CMSEntity
{
    public Level1()
    {
        Define<TagListChallenges>().all.Add(E.Id<Wave1>());
        Define<TagListChallenges>().all.Add(E.Id<Wave2>());
        Define<TagTier>().tier = 1;
        Define<TagLevelView>();
    }
}

public class Wave1 : CMSEntity
{
    public Wave1()
    {
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
    }
}

public class Wave2 : CMSEntity
{
    public Wave2()
    {
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
        Define<TagMobGroup>().mobGroup.Add(E.Id<Mushroom>());
    }
}