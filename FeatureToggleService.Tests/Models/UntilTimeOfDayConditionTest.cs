using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class UntilTimeOfDayConditionTest
    {
        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenCurrentTimeIsGreaterThanUntilTimeOfDay()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilTimeOfDayCondition(now.AddHours(-1).TimeOfDay);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsEqualToUntilTimeOfDay()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilTimeOfDayCondition(now.TimeOfDay);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsLessThanUntilTimeOfDay()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilTimeOfDayCondition(now.AddHours(1).TimeOfDay);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenContextIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilTimeOfDayCondition(now.AddHours(-1).TimeOfDay);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }
    }
}
