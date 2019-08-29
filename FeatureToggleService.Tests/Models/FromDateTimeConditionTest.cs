using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class FromDateTimeConditionTest
    {
        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsGreaterThanFromDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new FromDateTimeCondition(now.AddDays(-1));
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenCurrentTimeIsEqualToFromDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new FromDateTimeCondition(now);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenCurrentTimeIsLessThanFromDateTime()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new FromDateTimeCondition(now.AddDays(1));
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenContextIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new FromDateTimeCondition(now.AddDays(-1));

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }
    }
}
