using System;
using Engine.Math;
using Newtonsoft.Json;
using UnityEngine;
using UnityUtils;

namespace _Project.Source
{
    public class CMSEntityConverter : JsonConverter<CMSEntity>
    {
        public override CMSEntity ReadJson(JsonReader reader, Type objectType, CMSEntity existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string path = (string)reader.Value;
                return CMS.Get<CMSEntity>(path);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, CMSEntity value, JsonSerializer serializer)
        {
            writer.WriteValue(value.id);
        }
    }
    
    public class Vector2Converter : JsonConverter<Vector2>
    {
        public override Vector2 ReadJson(JsonReader reader, Type objectType, Vector2 existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string path = (string)reader.Value;
                return ParseVector2(path);
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, Vector2 value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.x};{value.y}");
        }
        
        private static Vector2 ParseVector2(string path)
        {
            var parts = path.Split(';');
            if (parts.Length == 2 &&
                float.TryParse(parts[0], out var x) &&
                float.TryParse(parts[1], out var y))
            {
                return new Vector2(x, y);
            }

            throw new JsonSerializationException($"Invalid Vector2 format: {path}");
        }
    }
    
    public class ColorConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string colorString = (string)reader.Value;
                return ParseColor(colorString);
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            writer.WriteValue(ColorUtility.ToHtmlStringRGBA(value));
        }

        private static Color ParseColor(string colorString)
        {
            colorString = $"#{colorString}";
            return colorString.ParseColor();
        }
    }

    
}