using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathSharp.Models.Enums
{
    public enum RuntimeType
    {
        Unattended,
        Studio,
        StudioX
    }

    public class RuntimeTypeConverter : JsonConverter<RuntimeType>
    {
        public override RuntimeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Reading of RuntimeType has not been implemented");
        }

        public override void Write(Utf8JsonWriter writer, RuntimeType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
