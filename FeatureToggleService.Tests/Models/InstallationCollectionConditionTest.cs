using FeatureToggleService.Conditions;
using FeatureToggleService.Misc;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class InstallationCollectionConditionTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenInstallationsAreNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new InstallationCollectionCondition(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenInstallationsAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new InstallationCollectionCondition());
        }

        [Fact]
        public void ConditionHoldsShouldReturnFalseWhenInstallationIsNotInInstallationsCollection()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var condition = new InstallationCollectionCondition("INSTALLATION#1", "INSTALLATION#2");
            var context = new Context(null, null, installation);

            // Act
            var conditionHolds = condition.Holds(context);

            // Assert
            Assert.False(conditionHolds);
        }

        [Fact]
        public void ConditionHoldsShouldReturnTrueWhenInstallationIsInInstallationsCollection()
        {
            // Arrange
            var installation = "SAMPLE_INSTALLATION";
            var condition = new InstallationCollectionCondition("INSTALLATION#1", "INSTALLATION#2", "SAMPLE_INSTALLATION");
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
            var condition = new InstallationCollectionCondition("INSTALLATION#1", "INSTALLATION#2");

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(null));
        }

        [Fact]
        public void ConditionHoldsShouldThrowExceptionWhenInstallationIsNotProvided()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var condition = new InstallationCollectionCondition("INSTALLATION#1", "INSTALLATION#2");
            var context = new Context(null, null, null);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => condition.Holds(context));
        }
    }
}
