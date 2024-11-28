using System.Collections.Generic;
using System.Linq;
using _Project.Data.Items;
using Cysharp.Threading.Tasks;

namespace _Project.Source.Scenes
{
    public class Party<T> where T : DungeonCharacter
    {
        public List<T> members = new List<T>();

        public bool CanAttack()
        {
            foreach (var character in members)
            {
                if (character.unit.CanAttack())
                {
                    return true;
                }
            }

            return false;
        }

        public List<T> GetParticipating()
        {
            return members.FindAll(character => character.IsParticipating());
        }

        public async UniTask ChangeMorale(FieldData fieldData, int i)
        {
            var tasks = members
                .OfType<DungeonHero>()
                .Select(async hero => await hero.ChangeMorale(i))
                .ToArray();

            await UniTask.WhenAll(tasks);
        }
    }
}