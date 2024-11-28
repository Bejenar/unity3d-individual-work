using System;
using Random = UnityEngine.Random;

namespace _Project.Source
{
    public static class NameGenerator
    {
        private static readonly string[][] NAME_PREFIX_PER_CLASS =
        {
            new string[] { "and", "for", "gro", "har", "jorg", "k", "bre" },
            new string[] { "arj", "prin", "ind", "ni", "ja", "aiv", "io" },
            new string[]
                { "hra", "Ra", "Ro", "Ke", "Fe", "Ko", "Gro", "Kho", "kro", "kra", "kre", "vo", "var", "Schry" },
            new string[] { "ay", "i", "a", "ey", "o", "u", "e", "oy" },
            new string[] { "kleo", "the", "ale", "mag", "arka", "deim", "ero", "kall" },
            new string[] { "vor", "luc", "ver", "jul", "flav", "cor", "vale", "viv", "van", "caer" },
            new string[] { "dex", "gliss", "tin", "hex", "glan", "glax", "shim", "wisp" }
        };

        private static readonly string[][] NAME_MIDDLE_PER_CLASS =
        {
            new string[] { "om", "arl", "erg", "ans", "ik", "ek", "er", "ir", "an" },
            new string[] { "hye", "n", "he", "so", "wok", "ed", "el", "e", "en", "er" },
            new string[] { "ky", "nef", "k", "se", "an", "rau", "mut", "kuf", "fuk", "grim", "hok", "onk" },
            new string[] { "m", "n", "h", "l", "w", "b" },
            new string[] { "the", "rhea", "phi", "phyl", "cle", "then", "eph", "mag" },
            new string[] { "a", "i", "an", "en", "el", "ar", "or", "in", "er" },
            new string[] { "alu", "alz", "avu", "cha", "hra", "tha", "igg", "obb" }
        };

        private static readonly string[][] NAME_SUFIX_PER_CLASS =
        {
            new string[] { "son", "en", "ik", "off", "iger", "oger", "arl", "eik", "arst", "erg" },
            new string[] { "esh", "a", "it", "an", "ika", "mani", "ak", "ak", "end" },
            new string[] { "orn", "und", "uh", "o", "or", "ok", "ug", "ulf", "arn" },
            new string[] { "ay", "i", "a", "y", "o", "u", "e", "oy", "il", "ol", "el", "in" },
            new string[] { "os", "phos", "ora", "tos", "mos", "phio", "dos", "idos" },
            new string[] { "ius", "ias", "cia", "cic", "dor", "ene", "lia" },
            new string[] { "anel", "arel", "asti", "efer", "ifer", "inel", "erel", "el" }
        };

        private static readonly int[][] NAME_LENGTHS =
        {
            new int[] { 0, 0, 0, 1, 1 },
            new int[] { 0, 0, 1 },
            new int[] { 0, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 0, 0, 1, 1, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 0, 0, 1 }
        };

        private static readonly string[] FALLBACK_NAMES = { "Uwe", "Ulf" };

        private static readonly string[] CLASS_IDS =
            { "Tank", "Ranger", "Barbarian", "Healer", "Mage", "Captain" };

        public static string GetRandomNameByClass(string desiredClass)
        {
            string heroName = "";
            int sourceIndex = Array.IndexOf(CLASS_IDS, desiredClass);
            if (sourceIndex < 0)
            {
                Console.WriteLine("invalid class name, picking from fallback cases name");
                heroName = FALLBACK_NAMES[Random.Range(0, FALLBACK_NAMES.Length)];
                return heroName;
            }

            string[] source = NAME_PREFIX_PER_CLASS[sourceIndex];
            int length = NAME_LENGTHS[sourceIndex][Random.Range(0, NAME_LENGTHS[sourceIndex].Length)];
            heroName += source[Random.Range(0, source.Length)];

            string pickedLast = null;
            for (int i = 0; i <= length; i++)
            {
                source = (i % 2 == 0) ? NAME_MIDDLE_PER_CLASS[sourceIndex] : NAME_SUFIX_PER_CLASS[sourceIndex];
                var pickedItem = source[Random.Range(0, source.Length)];
                while (pickedItem == pickedLast)
                {
                    pickedItem = source[Random.Range(0, source.Length)];
                }

                pickedLast = pickedItem;
                heroName += pickedItem;
            }

            return heroName;
        }
    }
}