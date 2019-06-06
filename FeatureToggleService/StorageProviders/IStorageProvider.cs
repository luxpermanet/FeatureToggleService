using System.Collections.Generic;
using FeatureToggleService.Serializers;

namespace FeatureToggleService.StorageProviders
{
    interface IStorageProvider
    {
        IEnumerable<string> GetFeatureToggleNames();
        SerializedFeatureToggle GetFeatureToggle(string featureName);
        bool HasFeatureToggle(string featureName);
        void SaveFeatureToggle(SerializedFeatureToggle serializedFeatureToggle);
        bool DeleteFeatureToggle(string featureName);
    }
}
