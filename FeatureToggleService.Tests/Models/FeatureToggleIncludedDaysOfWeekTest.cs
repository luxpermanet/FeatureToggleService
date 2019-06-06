using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleIncludedDaysOfWeekTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedDaysOfWeekAreNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedDaysOfWeek(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenIncludedDaysOfWeekAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleIncludedDaysOfWeek());
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenDayIsNotInIncludedDaysOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var featureToggle = new FeatureToggleIncludedDaysOfWeek(DayOfWeek.Monday, DayOfWeek.Tuesday);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenDayIsInIncludedDaysOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var featureToggle = new FeatureToggleIncludedDaysOfWeek(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }
    }
}
