using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class UsersConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenUsersAreNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new UsersCondition(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenUsersAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new UsersCondition());
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenUserIsNotInUsersCollection()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var condition = new UsersCondition("USER#1", "USER#2");
            var context = new Context(null, user, null);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenUserIsInUsersCollection()
        {
            // Arrange
            var user = "SAMPLE_USER";
            var condition = new UsersCondition("USER#1", "USER#2", "SAMPLE_USER");
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
            var condition = new UsersCondition("USER#1", "USER#2");

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenUserIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new UsersCondition("USER#1", "USER#2");
            var context = new Context(null, null, null);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(context));
        }
    }
}
