using FeatureToggleService.Serializers;

namespace FeatureToggleService.StorageProviders
{
    public class JsonFileStorageProvider : FileStorageProvider
    {
        private static readonly string FileExtension = "json";

        public JsonFileStorageProvider(string rootFolderPath) 
            : base(rootFolderPath, FileExtension, new JsonFeatureToggleSerializer()) {
        }
    }
}
