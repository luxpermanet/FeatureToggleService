using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class AndConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenLeftOperandIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new AndCondition(null, Allow.Simple()));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenRightOperandIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new AndCondition(Allow.Simple(), null));
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenBothOperandsAreTrue()
        {
            // Arrange
            var condition = Allow.Simple().And(Allow.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenLeftOperandIsFalse()
        {
            // Arrange
            var condition = Restrict.Simple().And(Allow.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenRightOperandIsFalse()
        {
            // Arrange
            var condition = Allow.Simple().And(Restrict.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }
    }
}
