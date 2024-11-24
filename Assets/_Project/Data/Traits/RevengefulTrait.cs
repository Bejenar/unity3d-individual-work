using _Project.Data.Items;
using _Project.Source.Scenes;
using Cysharp.Threading.Tasks;

namespace _Project.Data.Traits
{
    public class RevengefulTrait : CMSEntity
    {
        public RevengefulTrait()
        {
            Define<TagTraitView>().name = "Revengeful";
            Define<TagRevengeful>();
        }
    }

    public class TagRevengeful : EntityComponentDefinition
    {
    }
}