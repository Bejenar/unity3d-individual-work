using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using UnityEngine;

namespace _Project.Data
{
    public class ProgressionImporter
    {
        public void Import(BaseHeroClass hero, List<LevelDefinition> levels)
        {
            hero.Get<TagLevelProgression>().levels = levels;
        }

        public void ImportLevelProgressionData()
        {
            Debug.Log("<color=orange>Importing progression data</color>");
            var all = CMS.GetAll<BaseHeroClass>();
            var dataset = Resources.Load<TextAsset>("Balance/level_progression");

            using var reader = new StringReader(dataset.text);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                for (int j = 0; j < 6; j++)
                {
                    List<LevelDefinition> levels = new List<LevelDefinition>();
                    csv.Read();
                    var firstField = csv.GetField(0);
                    BaseHeroClass hero = all.Find(x => x.Get<TagClass>().loc == firstField);

                    csv.Read();

                    for (int i = 0; i < 10; i++)
                    {
                        csv.Read();
                        var levelDefinition = new LevelDefinition
                        {
                            maxHealth = csv.GetField<float>(1),
                            hitChance = csv.GetField<float>(2),
                            critChance = csv.GetField<float>(3),
                            evasion = csv.GetField<float>(4),
                            blockage = csv.GetField<float>(5),
                            baseDamageMin = csv.GetField<float>(6),
                            baseDamageMax = csv.GetField<float>(7),
                            maxMorale = csv.GetField<float>(8),
                            moraleBoostOnWin = csv.GetField<float>(9),
                            damageReduction = csv.GetField<float>(10)
                        };

                        levels.Add(levelDefinition);
                    }

                    if (hero == null) continue;
                    
                    Import(hero, levels);
                }
            }
            
            Debug.Log("<color=green>Progression data import done</color>");
        }
    }
}