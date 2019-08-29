using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class UntilDateTimeConditionTest
    {
        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenCurrentTimeIsGreaterThanUntilDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilDateTimeCondition(now.AddDays(-1));
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsEqualToUntilDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilDateTimeCondition(now);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsLessThanUntilDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UntilDateTimeCondition(now.AddDays(1));
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
            var condition = new UntilDateTimeCondition(now.AddDays(-1));

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }
    }
}
