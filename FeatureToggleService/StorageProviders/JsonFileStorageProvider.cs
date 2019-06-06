using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FeatureToggleService.Serializers;
using Newtonsoft.Json;

namespace FeatureToggleService.StorageProviders
{
    public class JsonFileStorageProvider : IStorageProvider
    {
        private static readonly string FileExtension = "json";

        private readonly string RootFilesPath;

        public JsonFileStorageProvider(string rootFilesPath)
        {
            if (string.IsNullOrWhiteSpace(rootFilesPath))
            {
                throw new ArgumentNullException(nameof(rootFilesPath));
            }
            
            RootFilesPath = rootFilesPath;
        }

        public bool DeleteFeatureToggle(string featureName)
        {
            var filePath = GetFilePath(featureName);
            if (!File.Exists(filePath)) { return false; }

            File.Delete(filePath);
            return true;
        }

        public bool HasFeatureToggle(string featureName) {
            var filePath = GetFilePath(featureName);
            return File.Exists(filePath);
        }

        public SerializedFeatureToggle GetFeatureToggle(string featureName)
        {
            var filePath = GetFilePath(featureName);
            if (!File.Exists(filePath))
            {
                throw new Exception($"FeatureToggle with the name: {featureName} could not be found");
            }

            var jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<SerializedFeatureToggle>(jsonContent, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });
        }

        public IEnumerable<string> GetFeatureToggleNames()
        {
            var fileNames = Directory.GetFiles(RootFilesPath);
            return fileNames.Select(fileName => GetFeatureToggleName(fileName));
        }

        public void SaveFeatureToggle(SerializedFeatureToggle serializedFeatureToggle)
        {
            var jsonContent = JsonConvert.SerializeObject(serializedFeatureToggle, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

            var filePath = GetFilePath(serializedFeatureToggle.FeatureName);
            File.WriteAllText(filePath, jsonContent);
        }

        private string GetFilePath(string featureName) {
            return $"{RootFilesPath}\\{featureName}.{FileExtension}";
        }

        private static string GetFeatureToggleName(string fileName) {
            return Path.GetFileNameWithoutExtension(fileName);
        }
    }
}
