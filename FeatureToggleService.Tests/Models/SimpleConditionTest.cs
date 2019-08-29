using FeatureToggleService.Conditions;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class SimpleConditionTest
    {
        [Fact]
        public void ConditionsHoldsShouldReturnTrueWhenTheConditionIsTrue()
        {
            // Arrange
            var condition = new SimpleCondition(true);

            // Act
            var conditionHolds = condition.Holds(null);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionsHoldsShouldReturnFalseWhenTheConditionIsFalse()
        {
            // Arrange
            var condition = new SimpleCondition(false);

            // Act
            var conditionHolds = condition.Holds(null);

            // Assert
            Assert.False(conditionHolds);
        }
    }
}
