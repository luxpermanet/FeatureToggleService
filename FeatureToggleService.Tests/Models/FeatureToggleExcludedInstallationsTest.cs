using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleExcludedInstallationsTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedInstallationsAreNull() {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedInstallations(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedInstallationsAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedInstallations());
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenInstallationIsNotInExcludedInstallations()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var featureToggle = new FeatureToggleExcludedInstallations("EXCLUDED_INSTALLATION#1", "EXCLUDED_INSTALLATION#2");
            featureToggle.InjectContext(null, null, installation);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenInstallationIsInExcludedInstallations()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var featureToggle = new FeatureToggleExcludedInstallations("EXCLUDED_INSTALLATION#1", "EXCLUDED_INSTALLATION#2", "SAMPLE_INSTALLATION");
            featureToggle.InjectContext(null, null, installation);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
