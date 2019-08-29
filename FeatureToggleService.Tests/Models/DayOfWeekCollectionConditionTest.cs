using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class DayOfWeekCollectionConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenDaysOfWeekAreNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new DayOfWeekCollectionCondition(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenDaysOfWeekAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new DayOfWeekCollectionCondition());
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenDayIsNotInDaysOfWeekCollection()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var condition = new DayOfWeekCollectionCondition(DayOfWeek.Monday, DayOfWeek.Tuesday);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenDayIsInDaysOfWeekCollection()
        {
            // Arrange
            var now = new DateTime(2019, 5, 15); // Wednesday
            var condition = new DayOfWeekCollectionCondition(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday);
            var context = new Context(now, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }
    }
}
