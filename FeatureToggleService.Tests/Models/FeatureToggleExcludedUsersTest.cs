using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleExcludedUsersTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedUsersAreNull() {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedUsers(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedUsersAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedUsers());
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenUserIsNotInExcludedUsers()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var featureToggle = new FeatureToggleExcludedUsers("EXCLUDED_USER#1", "EXCLUDED_USER#2");
            featureToggle.InjectContext(null, user, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenUserIsInExcludedUsers()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var featureToggle = new FeatureToggleExcludedUsers("EXCLUDED_USER#1", "EXCLUDED_USER#2", "SAMPLE_USER");
            featureToggle.InjectContext(null, user, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
