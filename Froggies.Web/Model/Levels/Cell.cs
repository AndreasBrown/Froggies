using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Froggies.Web.Model.Levels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Cell
    {
        [EnumMember(Value = "E")] Empty,
        [EnumMember(Value = "N")] None,
        [EnumMember(Value = "R")] RedFrog,
        [EnumMember(Value = "G")] GreenFrog,
    }
}
