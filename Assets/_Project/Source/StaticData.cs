using UnityEngine;

namespace _Project.Source
{
    public static class StaticData
    {
        public static readonly string HairMatName = "Hair"; // TODO replace with hasProperty "_Tint" and set "_TintInfluence" to 1
        
        public static readonly int TintValue = Shader.PropertyToID("_TintValue");
        public static readonly int Tint = Shader.PropertyToID("_Tint");
        public static readonly int DarkColor = Shader.PropertyToID("_DarkColor");
        public static readonly int LitColor = Shader.PropertyToID("_LitColor");
    }
}