using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class InstallationConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenInstallationIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new InstallationCondition(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenInstallationIsEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new InstallationCondition(string.Empty));
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenInstallationIsNotEqualToInstallation()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var condition = new InstallationCondition("INSTALLATION#1");
            var context = new Context(null, null, installation);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenInstallationIsEqualToInstallation()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var condition = new InstallationCondition("SAMPLE_INSTALLATION");
            var context = new Context(null, null, installation);

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
            var condition = new InstallationCondition("INSTALLATION#1");

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenInstallationIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new InstallationCondition("INSTALLATION#1");
            var context = new Context(null, null, null);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(context));
        }
    }
}
