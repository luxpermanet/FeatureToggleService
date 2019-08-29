using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class OrConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenLeftOperandIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new OrCondition(null, Allow.Simple()));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenRightOperandIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new OrCondition(Allow.Simple(), null));
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenLeftOperandIsTrue()
        {
            // Arrange
            var condition = Allow.Simple().Or(Restrict.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenRightOperandIsTrue()
        {
            // Arrange
            var condition = Restrict.Simple().Or(Allow.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.True(conditionHolds);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenBothOperandsAreFalse()
        {
            // Arrange
            var condition = Restrict.Simple().Or(Restrict.Simple());
            var context = new Context(null, null, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }
    }
}
