using SerializerToJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using static SerializerToJson.SystemTextJsonConverter;
using static SerializerToJson.NewtonsoftJsonConverter;

#region Base data to Serialize

var personModel = new Person
{
    Id = 1,
    FirstName = "John",
    LastName = "Snow",
    NationalCode = "0854552200",
    //BirthDate = new DateOnly(1999, 04, 16),
    RegisterDate = DateTime.Now,
    FatherName = "David",
    UniqueId = Guid.NewGuid()
};

var anonymousObj = new // Anonymous object to convert to Json
{
    FirstName = "John",
    LastName = "Smith"
};

dynamic dynObj = new ExpandoObject(); // Dynamic object to convert to Json
dynObj.Name = "Corey Richards";
dynObj.Address = "3519 Woodburn Rd";

var dateTimeObj = new // DateTime object to convert to Json using helper
{
    DateCreated = new DateTime(2023, 01, 01)
};

var employee = new Employee { FirstName = "John", LastName = "Smith" };
var department = new Department { Name = "Human Resources" };
employee.Department = department;
department.Staff.Add(employee);

#endregion Base data to Serialize

#region System.Text.Json

Console.WriteLine("====System.Text.Json========================================");

var optionsSTJ = new JsonSerializerOptions
{
    WriteIndented = true, // To “pretty” JSON string.
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // To make propertios Camel Case.
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // To hide properties with Null value.
    //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault, // To hide properties with Dafault value.
};

var SystemTextJson_String = ConvertDefinedModelUsingSystemTextJson(personModel, optionsSTJ);
Console.WriteLine($"System.Text.Json - Person: {SystemTextJson_String}");

Console.WriteLine("");

var SystemTextJson_Anonymous = ConvertDynamicAnonymousModelUsingSystemTextJson(anonymousObj, optionsSTJ);
Console.WriteLine($"System.Text.Json - AnonymousObj: {SystemTextJson_Anonymous}");

Console.WriteLine("");

var SystemTextJson_Dynamic = ConvertDynamicAnonymousModelUsingSystemTextJson(dynObj, optionsSTJ);
Console.WriteLine($"System.Text.Json - DynamicObj: {SystemTextJson_Dynamic}");

Console.WriteLine("");

var options = new JsonSerializerOptions();
options.Converters.Add(new STJDateTimeHelper());

var SystemTextJson_DateTime = ConvertDynamicAnonymousModelUsingSystemTextJson(dateTimeObj, options);
Console.WriteLine($"System.Text.Json - DateTimeObj: {SystemTextJson_DateTime}");

Console.WriteLine("");

var loopOptionsPreserved = new JsonSerializerOptions
{
    WriteIndented = true, // To “pretty” JSON string.
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // To make propertios Camel Case.
    ReferenceHandler = ReferenceHandler.Preserve
};

var SystemTextJson_LoopReferencePreserved = ConvertDynamicAnonymousModelUsingSystemTextJson(employee, loopOptionsPreserved);
Console.WriteLine($"System.Text.Json - LoopReferencePreservedObj: {SystemTextJson_LoopReferencePreserved}");

var loopOptionsIgnored = new JsonSerializerOptions
{
    WriteIndented = true, // To “pretty” JSON string.
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // To make propertios Camel Case.
    ReferenceHandler = ReferenceHandler.IgnoreCycles
};

var SystemTextJson_LoopReferenceIgnored = ConvertDynamicAnonymousModelUsingSystemTextJson(employee, loopOptionsIgnored);
Console.WriteLine($"System.Text.Json - LoopReferenceIgnoredObj: {SystemTextJson_LoopReferenceIgnored}");

Console.WriteLine("====System.Text.Json========================================");

#endregion System.Text.Json

Console.WriteLine("");
Console.WriteLine("============================================================");
Console.WriteLine("");

#region Newtonsoft.Json

Console.WriteLine("====Newtonsoft.Json=========================================");

var optionsNSJ = new JsonSerializerSettings
{
    Formatting = Formatting.Indented, // To “pretty” JSON string.
    ContractResolver = new CamelCasePropertyNamesContractResolver(), // To make propertios Camel Case.
    NullValueHandling = NullValueHandling.Ignore, // To hide properties with Null value.
    DefaultValueHandling = DefaultValueHandling.Ignore // To hide properties with Default value.
};

var NewtonsofJson_String = ConvertDefinedModelUsingNewtonsoftJson(personModel, optionsNSJ);
Console.WriteLine($"NewtonsofJson - Person: { NewtonsofJson_String}");

Console.WriteLine("");

var NewtonsofJson_Anonymous = ConvertDynamicAnonymousModelUsingNewtonsoftJson(anonymousObj, optionsNSJ);
Console.WriteLine($"NewtonsofJson - AnonymousObj: {NewtonsofJson_Anonymous}");

Console.WriteLine("");

var NewtonsofJson_Dynamic = ConvertDynamicAnonymousModelUsingNewtonsoftJson(dynObj, optionsNSJ);
Console.WriteLine($"NewtonsofJson - DynamicObj: {NewtonsofJson_Dynamic}");

Console.WriteLine("");

var NewtonsofJson_DateTime = ConvertDateTimeUsingNewtonsoftJson(dateTimeObj, new NSJDateTimeHelper());
Console.WriteLine($"NewtonsofJson - DateTimeObj: {NewtonsofJson_DateTime}");

Console.WriteLine("");

var NewtonsofJson_LoopReference = ConvertDynamicAnonymousModelUsingNewtonsoftJson(employee, optionsNSJ);
Console.WriteLine($"NewtonsofJson - LoopReference: {NewtonsofJson_LoopReference}");

Console.WriteLine("====Newtonsoft.Json=========================================");

#endregion  Newtonsoft.Json

Console.ReadLine();