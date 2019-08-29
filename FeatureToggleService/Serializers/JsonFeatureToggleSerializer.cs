using FeatureToggleService.Models;
using Newtonsoft.Json;

namespace FeatureToggleService.Serializers
{
    public class JsonFeatureToggleSerializer : IFeatureToggleSerializer
    {
        public FeatureToggle Deserialize(string jsonContent)
        {
            return JsonConvert.DeserializeObject<FeatureToggle>(jsonContent, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string Serialize(FeatureToggle serializedFeatureToggle)
        {
            return JsonConvert.SerializeObject(serializedFeatureToggle, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                TypeNameHandling = TypeNameHandling.All
            });
        }
    }
}
