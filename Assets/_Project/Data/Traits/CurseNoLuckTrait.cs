namespace _Project.Data.Traits
{
    public class CurseNoLuckTrait : CMSEntity
    {
        // Can not crit
        public CurseNoLuckTrait()
        {
            Define<TagTraitView>().name = "Curse No Luck";
            Define<TagCurseNoLuck>();
        }
    }
    
    public class TagCurseNoLuck : EntityComponentDefinition
    {
    }
}