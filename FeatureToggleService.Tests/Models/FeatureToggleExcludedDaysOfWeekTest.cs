using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleExcludedDaysOfWeekTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedDaysOfWeekAreNull() {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedDaysOfWeek(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenExcludedDaysOfWeekAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleExcludedDaysOfWeek());
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenDayIsNotInExcludedDaysOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var featureToggle = new FeatureToggleExcludedDaysOfWeek(DayOfWeek.Monday, DayOfWeek.Tuesday);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenDayIsInExcludedDaysOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var featureToggle = new FeatureToggleExcludedDaysOfWeek(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
