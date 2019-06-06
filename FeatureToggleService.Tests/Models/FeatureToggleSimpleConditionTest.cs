using FeatureToggles.Models;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleSimpleConditionTest
    {
        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenTheConditionIsTrue() {
            // Arrange
            var featureToggle = new FeatureToggleSimpleCondition(true);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenTheConditionIsFalse()
        {
            // Arrange
            var featureToggle = new FeatureToggleSimpleCondition(false);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
