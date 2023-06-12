using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathSharp.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetJsonProperty(this string json, string propertyName)
        {
            return JsonDocument.Parse(json).RootElement.GetProperty(propertyName).GetRawText(); // take out the json from the field with the name that was provided
        }
    }
}
