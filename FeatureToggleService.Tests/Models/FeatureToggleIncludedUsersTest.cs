using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleIncludedUsersTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedUsersAreNull() {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedUsers(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedUsersAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedUsers());
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenUserIsNotInIncludedUsers()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var featureToggle = new FeatureToggleIncludedUsers("INCLUDED_USER#1", "INCLUDED_USER#2");
            featureToggle.InjectContext(null, user, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenUserIsInIncludedUsers()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var featureToggle = new FeatureToggleIncludedUsers("INCLUDED_USER#1", "INCLUDED_USER#2", "SAMPLE_USER");
            featureToggle.InjectContext(null, user, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }
    }
}
