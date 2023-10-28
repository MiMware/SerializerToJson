using Newtonsoft.Json;

namespace SerializerToJson
{
    public static class NewtonsoftJsonConverter
    {
        public static string ConvertDefinedModelUsingNewtonsoftJson(Person personModel, JsonSerializerSettings options)
        {
            var result = JsonConvert.SerializeObject(personModel, options);

            return result;
        }

        public static string ConvertDynamicAnonymousModelUsingNewtonsoftJson(dynamic anonymousObj, JsonSerializerSettings options)
        {
            var result = JsonConvert.SerializeObject(anonymousObj, options); ;

            return result;
        }

        public static string ConvertDateTimeUsingNewtonsoftJson(dynamic anonymousObj, NSJDateTimeHelper helper)
        {
            var result = JsonConvert.SerializeObject(anonymousObj, helper); ;

            return result;
        }
    }
}