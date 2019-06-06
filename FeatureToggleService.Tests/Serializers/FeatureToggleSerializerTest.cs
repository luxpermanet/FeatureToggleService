using FeatureToggles.Models;
using FeatureToggleService.Serializers;
using Newtonsoft.Json;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Serializers
{
    public class FeatureToggleSerializerTest
    {
        private static readonly string SampleFeatureToggleAsJsonString = @"{
  ""FeatureName"": ""RunInBackground"",
  ""SerializedFeatureToggleEntities"": [
    {
      ""Condition"": true
    },
    {
      ""DateTimeIntervalBegin"": ""2019-05-16T15:00:00"",
      ""DateTimeIntervalEnd"": ""2019-05-17T15:00:00"",
      ""ExcludedDaysOfWeek"": ""Wednesday"",
      ""ExcludedInstallations"": ""SAMPLE_INSTALLATION#2"",
      ""ExcludedUsers"": ""USER#2"",
      ""IncludedDaysOfWeek"": ""Monday;Tuesday;Thursday;Friday;Saturday;Sunday"",
      ""IncludedInstallations"": ""SAMPLE_INSTALLATION#1"",
      ""IncludedUsers"": ""USER#1"",
      ""Condition"": false,
      ""TimeOfDayIntervalBegin"": ""15:00:00"",
      ""TimeOfDayIntervalEnd"": ""16:00:00""
    }
  ]
}";
        
        [Fact]
        public void DeserializeTest()
        {
            // Arrange
            var serializedFeatureToggle = JsonConvert.DeserializeObject<SerializedFeatureToggle>(SampleFeatureToggleAsJsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

            // Act
            var actualFeatureToggle = FeatureToggleSerializer.Deserialize(serializedFeatureToggle);

            // Assert
            Assert.IsType<SatisfyAnyCompositeFeatureToggle>(actualFeatureToggle);
            var satisfyAnyCompositeFeatureToggle = (SatisfyAnyCompositeFeatureToggle)actualFeatureToggle;
            Assert.Equal(2, satisfyAnyCompositeFeatureToggle.AnyShallPass.Length);

            Assert.IsType<FeatureToggleSimpleCondition>(satisfyAnyCompositeFeatureToggle.AnyShallPass[0]);
            var simpleCondition = (FeatureToggleSimpleCondition)satisfyAnyCompositeFeatureToggle.AnyShallPass[0];
            Assert.True(simpleCondition.Condition);

            Assert.IsType<SatisfyAllCompositeFeatureToggle>(satisfyAnyCompositeFeatureToggle.AnyShallPass[1]);
            var secondComposite = (SatisfyAllCompositeFeatureToggle)satisfyAnyCompositeFeatureToggle.AnyShallPass[1];
            Assert.Equal(9, secondComposite.AllShallPass.Length);

            Assert.IsType<FeatureToggleSimpleCondition>(secondComposite.AllShallPass[0]);
            simpleCondition = (FeatureToggleSimpleCondition)secondComposite.AllShallPass[0];
            Assert.False(simpleCondition.Condition);

            Assert.IsType<FeatureToggleDateTimeInterval>(secondComposite.AllShallPass[1]);
            var dateTimeInterval = (FeatureToggleDateTimeInterval)secondComposite.AllShallPass[1];
            Assert.Equal(new DateTime(2019, 5, 16, 15, 0, 0, 0), dateTimeInterval.DateTimeIntervalBegin);
            Assert.Equal(new DateTime(2019, 5, 17, 15, 0, 0, 0), dateTimeInterval.DateTimeIntervalEnd);

            Assert.IsType<FeatureToggleExcludedDaysOfWeek>(secondComposite.AllShallPass[2]);
            var excludedDaysOfWeek = (FeatureToggleExcludedDaysOfWeek)secondComposite.AllShallPass[2];
            Assert.Equal(new[] { DayOfWeek.Wednesday }, excludedDaysOfWeek.ExcludedDaysOfWeek);

            Assert.IsType<FeatureToggleExcludedInstallations>(secondComposite.AllShallPass[3]);
            var excludedInstallations = (FeatureToggleExcludedInstallations)secondComposite.AllShallPass[3];
            Assert.Equal(new[] { "SAMPLE_INSTALLATION#2" }, excludedInstallations.ExcludedInstallations);

            Assert.IsType<FeatureToggleExcludedUsers>(secondComposite.AllShallPass[4]);
            var excludedUsers = (FeatureToggleExcludedUsers)secondComposite.AllShallPass[4];
            Assert.Equal(new[] { "USER#2" }, excludedUsers.ExcludedUsers);

            Assert.IsType<FeatureToggleIncludedDaysOfWeek>(secondComposite.AllShallPass[5]);
            var includedDaysOfWeek = (FeatureToggleIncludedDaysOfWeek)secondComposite.AllShallPass[5];
            Assert.Equal(new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }, includedDaysOfWeek.IncludedDaysOfWeek);

            Assert.IsType<FeatureToggleIncludedInstallations>(secondComposite.AllShallPass[6]);
            var includedInstallations = (FeatureToggleIncludedInstallations)secondComposite.AllShallPass[6];
            Assert.Equal(new[] { "SAMPLE_INSTALLATION#1" }, includedInstallations.IncludedInstallations);

            Assert.IsType<FeatureToggleIncludedUsers>(secondComposite.AllShallPass[7]);
            var includedUsers = (FeatureToggleIncludedUsers)secondComposite.AllShallPass[7];
            Assert.Equal(new[] { "USER#1" }, includedUsers.IncludedUsers);

            Assert.IsType<FeatureToggleTimeOfDayInterval>(secondComposite.AllShallPass[8]);
            var timeOfDayInterval = (FeatureToggleTimeOfDayInterval)secondComposite.AllShallPass[8];
            Assert.Equal(new TimeSpan(15, 0, 0), timeOfDayInterval.TimeOfDayIntervalBegin);
            Assert.Equal(new TimeSpan(16, 0, 0), timeOfDayInterval.TimeOfDayIntervalEnd);
        }
    }
}
