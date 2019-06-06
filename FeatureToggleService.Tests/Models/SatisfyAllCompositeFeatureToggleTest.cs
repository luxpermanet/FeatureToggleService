﻿using FeatureToggles.Models;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Models
{
    public class SatisfyAllCompositeFeatureToggleTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionWhenFeatureToggleComponentsAreNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new SatisfyAllCompositeFeatureToggle(null));
        }

        [Fact]
        public void ConstructorShouldThrowExceptionWhenFeatureToggleComponentsAreEmpty()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new SatisfyAllCompositeFeatureToggle());
        }

        [Fact]
        public void FeatureEnabledShouldReturnTrueWhenAllComponentsAreTrue()
        {
            // Arrange
            var featureToggle1 = new FeatureToggleSimpleCondition(true);
            var featureToggle2 = new FeatureToggleSimpleCondition(true);
            var featureToggle = new SatisfyAllCompositeFeatureToggle(featureToggle1, featureToggle2);
            featureToggle.InjectContext(null, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }

        [Fact]
        public void FeatureEnabledShouldReturnFalseWhenOneComponentsIsFalse()
        {
            // Arrange
            var featureToggle1 = new FeatureToggleSimpleCondition(true);
            var featureToggle2 = new FeatureToggleSimpleCondition(false);
            var featureToggle = new SatisfyAllCompositeFeatureToggle(featureToggle1, featureToggle2);
            featureToggle.InjectContext(null, null, null);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.False(featureEnabled);
        }

        [Fact]
        public void InjectContextShouldBePropagatedToComponents()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var user = "SAMPLE_USER";
            var installation = "SAMPLE_INSTALLATION";
            var featureToggle1 = new FeatureToggleDateTimeInterval(now.AddDays(-1), now.AddDays(1));
            var featureToggle2 = new FeatureToggleIncludedUsers("SAMPLE_USER");
            var featureToggle3 = new FeatureToggleIncludedInstallations("SAMPLE_INSTALLATION");
            var featureToggle = new SatisfyAllCompositeFeatureToggle(featureToggle1, featureToggle2, featureToggle3);
            featureToggle.InjectContext(now, user, installation);

            // Act
            var featureEnabled = featureToggle.FeatureEnabled;

            // Assert
            Assert.True(featureEnabled);
        }
    }
}
