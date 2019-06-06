using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleIncludedInstallationsTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedInstallationsAreNull() {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedInstallations(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedInstallationsAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedInstallations());
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenInstallationIsNotInIncludedInstallations()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var featureToggle = new FeatureToggleIncludedInstallations("INCLUDED_INSTALLATION#1", "INCLUDED_INSTALLATION#2");
            featureToggle.InjectContext(null, null, installation);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenInstallationIsInIncludedInstallations()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var featureToggle = new FeatureToggleIncludedInstallations("INCLUDED_INSTALLATION#1", "INCLUDED_INSTALLATION#2", "SAMPLE_INSTALLATION");
            featureToggle.InjectContext(null, null, installation);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }
    }
}
