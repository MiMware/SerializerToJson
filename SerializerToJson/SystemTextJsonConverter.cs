using System.Text.Json;

namespace SerializerToJson
{
    public static class SystemTextJsonConverter
    {
        public static string ConvertDefinedModelUsingSystemTextJson(Person personModel, JsonSerializerOptions options)
        {
            var result = JsonSerializer.Serialize(personModel, options);

            return result;
        }

        public static string ConvertDynamicAnonymousModelUsingSystemTextJson(dynamic anonymousObj, JsonSerializerOptions options)
        {
            var result = JsonSerializer.Serialize(anonymousObj, options); ;

            return result;
        }
    }
}