using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class UserConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenUserIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new UserCondition(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenUserIsEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new UserCondition(string.Empty));
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenUserIsNotEqualToUser()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var condition = new UserCondition("USER#1");
            var context = new Context(null, user, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenUserIsEqualToUser()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var condition = new UserCondition("SAMPLE_USER");
            var context = new Context(null, user, null);

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
            var condition = new UserCondition("USER#1");

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenUserIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UserCondition("USER#1");
            var context = new Context(null, null, null);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(context));
        }
    }
}
