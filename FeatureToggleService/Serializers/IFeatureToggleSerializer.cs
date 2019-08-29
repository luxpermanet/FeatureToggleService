using FeatureToggleService.Models;

namespace FeatureToggleService.Serializers
{
    public interface IFeatureToggleSerializer
    {
        FeatureToggle Deserialize(string jsonContent);
        string Serialize(FeatureToggle serializedFeatureToggle);
    }
}
