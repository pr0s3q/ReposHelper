using Newtonsoft.Json;
using ReposHelper;

#pragma warning disable IDE0079
#pragma warning disable CA1416
Item item = new(EItemType.Bug, 97, "In Progress", "Serialize test object", 3, DateTime.Now,
    "Create simple object and serialize it to JSON", string.Empty, Array.Empty<string>());

string result = JsonConvert.SerializeObject(item);
Console.WriteLine(result);

JsonSerializer json = new();
using (StreamWriter sw = new StreamWriter(@"../../../result.json"))
using (JsonWriter writer = new JsonTextWriter(sw))
{
    json.Serialize(writer, item);
}
