using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FeatureToggleService.Models;
using FeatureToggleService.Serializers;

namespace FeatureToggleService.StorageProviders
{
    public abstract class FileStorageProvider : IStorageProvider
    {
        private readonly string RootFolderPath;
        private readonly string FileExtension;
        private readonly IFeatureToggleSerializer Serializer;

        public FileStorageProvider(string rootFolderPath, string fileExtension, IFeatureToggleSerializer serializer)
        {
            if (string.IsNullOrEmpty(rootFolderPath))
            {
                throw new ArgumentNullException(nameof(rootFolderPath));
            }
            if (string.IsNullOrEmpty(fileExtension))
            {
                throw new ArgumentNullException(nameof(fileExtension));
            }
            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            RootFolderPath = rootFolderPath;
            FileExtension = fileExtension;
            Serializer = serializer;
        }

        public bool DeleteFeatureToggle(string featureName)
        {
            var filePath = GetFilePath(featureName);
            if (!File.Exists(filePath)) { return false; }

            File.Delete(filePath);
            return true;
        }

        public FeatureToggle GetFeatureToggle(string featureName)
        {
            var filePath = GetFilePath(featureName);
            if (!File.Exists(filePath))
            {
                throw new Exception($"FeatureToggle with the name: {featureName} could not be found");
            }

            var jsonContent = File.ReadAllText(filePath);
            return Serializer.Deserialize(jsonContent);
        }

        public IEnumerable<string> GetFeatureToggleNames()
        {
            var fileNames = Directory.GetFiles(RootFolderPath);
            return fileNames.Select(fileName => GetFeatureToggleName(fileName));
        }

        public bool HasFeatureToggle(string featureName)
        {
            var filePath = GetFilePath(featureName);
            return File.Exists(filePath);
        }

        public void SaveFeatureToggle(FeatureToggle serializedFeatureToggle)
        {
            var jsonContent = Serializer.Serialize(serializedFeatureToggle);
            var filePath = GetFilePath(serializedFeatureToggle.FeatureName);
            File.WriteAllText(filePath, jsonContent);
        }

        private string GetFilePath(string featureName)
        {
            return $"{RootFolderPath}\\{featureName}.{FileExtension}";
        }

        private static string GetFeatureToggleName(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName);
        }
    }
}
