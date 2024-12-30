



using System.Text.Json;
using System.Text.Json.Serialization;


    public class EnumToStringConverter<T> : JsonConverter<T> where T : struct, Enum
{
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
         
            var value = reader.GetString();
            if (Enum.TryParse<T>(value, true , out var enumValue))
            {
                return enumValue;
            }

            throw new JsonException($"Unable to convert \"{value}\" to Enum \"{typeof(T)}\"");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }


