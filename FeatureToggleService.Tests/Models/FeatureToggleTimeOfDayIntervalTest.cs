using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleTimeOfDayIntervalTest
    {
        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenCurrentTimeIsBetweenInterval()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(-1).TimeOfDay, now.AddHours(1).TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;
            
            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenCurrentTimeIsEqualToIntervalBegin()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.TimeOfDay, now.AddHours(1).TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenCurrentTimeIsEqualToIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(-1).TimeOfDay, now.TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenCurrentTimeIsOutsideInterval()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(1).TimeOfDay, now.AddHours(2).TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldThrowExceptionWhenCurrentTimeIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(-1).TimeOfDay, now.AddHours(1).TimeOfDay);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => featureToggle.FeatureEnabled);
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenIntervalBeginIsGreaterThanIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new FeatureToggleTimeOfDayInterval(now.AddHours(1).TimeOfDay, now.AddHours(-1).TimeOfDay));
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenIntervalBeginIsNullAndCurrentTimeIsLessThanIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(null, now.AddHours(1).TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenIntervalBeginIsNullAndCurrentTimeIsEqualToIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(null, now.TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenIntervalBeginIsNullAndCurrentTimeIsGreaterThanIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(null, now.AddHours(-1).TimeOfDay);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenIntervalEndIsNullAndCurrentTimeIsGreaterThanIntervalBegin()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(-1).TimeOfDay, null);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenIntervalEndIsNullAndCurrentTimeIsEqualToIntervalBegin()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.TimeOfDay, null);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenIntervalEndIsNullAndCurrentTimeIsLessThanIntervalBegin()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleTimeOfDayInterval(now.AddHours(1).TimeOfDay, null);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
