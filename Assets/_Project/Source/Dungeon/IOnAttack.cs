using _Project.Source;
using Cysharp.Threading.Tasks;

namespace _Project.Data.Items
{
    public interface IOnAttack
    {
        UniTask OnAttack(FieldData data, DungeonCharacter actor);
    }
}