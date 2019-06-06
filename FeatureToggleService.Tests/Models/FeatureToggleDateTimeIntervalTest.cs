using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FeatureToggleDateTimeIntervalTest
    {
        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenCurrentTimeIsBetweenInterval()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(-1), now.AddDays(1));
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
            var featureToggle = new FeatureToggleDateTimeInterval(now, now.AddDays(1));
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
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(-1), now);
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
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(1), now.AddDays(2));
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
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(-1), now.AddDays(1));

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
            Assert.Throws<ArgumentException>(() => new FeatureToggleDateTimeInterval(now.AddDays(1), now.AddDays(-1)));
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenIntervalBeginIsNullAndCurrentTimeIsLessThanIntervalEnd()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var featureToggle = new FeatureToggleDateTimeInterval(null, now.AddDays(1));
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
            var featureToggle = new FeatureToggleDateTimeInterval(null, now);
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
            var featureToggle = new FeatureToggleDateTimeInterval(null, now.AddDays(-1));
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
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(-1), null);
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
            var featureToggle = new FeatureToggleDateTimeInterval(now, null);
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
            var featureToggle = new FeatureToggleDateTimeInterval(now.AddDays(1), null);
            featureToggle.InjectContext(now, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }
    }
}
