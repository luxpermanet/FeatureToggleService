using System.Collections.Generic;
using FeatureToggleService.Models;

namespace FeatureToggleService.StorageProviders
{
    interface IStorageProvider
    {
        IEnumerable<string> GetFeatureToggleNames();
        FeatureToggle GetFeatureToggle(string featureName);
        bool HasFeatureToggle(string featureName);
        void SaveFeatureToggle(FeatureToggle serializedFeatureToggle);
        bool DeleteFeatureToggle(string featureName);
    }
}
