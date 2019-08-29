using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class DayOfWeekConditionTest
    {
        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenDayIsNotEqualToDayOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var condition = new DayOfWeekCondition(DayOfWeek.Monday);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenDayIsEqualToDayOfWeek()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var condition = new DayOfWeekCondition(DayOfWeek.Wednesday);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }
    }
}
