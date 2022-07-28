using Newtonsoft.Json;
using ReposHelper;

#pragma warning disable CA1416 // Validate platform compatibility

namespace UnitTests
{
    public class ItemTests
    {
        [Fact]
        public void SerializeSingleObject()
        {
            Item item = new(EItemType.Bug, 97, "In Progress", "Serialize test object", 3, DateTime.Parse("2022-07-28T19:48:53.4551046+02:00"),
                "Create simple object and serialize it to JSON", string.Empty, Array.Empty<string>());
            string expectedResult = "{\"Type\":0,\"Id\":97,\"Status\":\"In Progress\",\"ShortTitle\":\"Serialize test object\",\"Priority\":3,\"CreationDate\":\"2022-07-28T19:48:53.4551046+02:00\",\"Description\":\"Create simple object and serialize it to JSON\",\"BranchName\":\"\",\"MergedTo\":[]}";
            Assert.Equal(expectedResult, JsonConvert.SerializeObject(item));
        }

        [Fact]
        public void DeserializeSingleObject()
        {
            Item item = new(EItemType.Bug, 97, "In Progress", "Serialize test object", 3, DateTime.Parse("2022-07-28T19:48:53.4551046+02:00"),
                "Create simple object and serialize it to JSON", string.Empty, Array.Empty<string>());
            Item deserializedItem = JsonConvert.DeserializeObject<Item>("{\"Type\":0,\"Id\":97,\"Status\":\"In Progress\",\"ShortTitle\":\"Serialize test object\",\"Priority\":3,\"CreationDate\":\"2022-07-28T19:48:53.4551046+02:00\",\"Description\":\"Create simple object and serialize it to JSON\",\"BranchName\":\"\",\"MergedTo\":[]}");
            Assert.Equal(deserializedItem, item);
        }
    }
}