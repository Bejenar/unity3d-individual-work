using UnityEngine;

namespace _Project.Source
{
    public static class StaticData
    {
        public static readonly string HairMatName = "m_ToonHair"; // TODO replace with hasProperty "_Tint" and set "_TintInfluence" to 1
        
        public static readonly int DarkColor = Shader.PropertyToID("_DarkColor");
        public static readonly int LitColor = Shader.PropertyToID("_LitColor");
    }
}