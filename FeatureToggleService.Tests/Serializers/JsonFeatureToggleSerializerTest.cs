using FeatureToggleService.Misc;
using FeatureToggleService.Models;
using FeatureToggleService.Serializers;
using System;
using Xunit;

namespace FeatureToggleService.Tests.Serializers
{
    public class JsonFeatureToggleSerializerTest
    {
        [Fact]
        public void Serialize() {
            // Assign
            var serializer = new JsonFeatureToggleSerializer();
            var condition = Allow.Simple()
                .Or(Allow.FromDateTime(new DateTime(2019, 05, 16, 15, 0, 0, DateTimeKind.Utc))
                    .And(Allow.UntilDateTime(new DateTime(2019, 05, 17, 15, 0, 0, DateTimeKind.Utc)))
                    .And(Restrict.DaysOfWeek(DayOfWeek.Wednesday))
                    .And(Restrict.Installations("SAMPLE_INSTALLATION#2"))
                    .And(Restrict.Users("USER#2"))
                    .And(Allow.DaysOfWeek(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday))
                    .And(Allow.Installations("SAMPLE_INSTALLATION#1"))
                    .And(Allow.Users("USER#1"))
                    .And(Restrict.Simple())
                    .And(Allow.FromTimeOfDay(new TimeSpan(15, 0, 0)))
                    .And(Allow.UntilTimeOfDay(new TimeSpan(16, 0, 0)))
                );
            var featureToggle = new FeatureToggle();
            featureToggle.FeatureName = "MyFeature";
            featureToggle.Condition = condition;

            // Act
            var serialized = serializer.Serialize(featureToggle);

            // Assert
            // Assert correctly. Don't read the expected from the static variable but from a static file
        }

        [Fact]
        public void Deserialize()
        {
            // Assign
            var serializer = new JsonFeatureToggleSerializer();
            var serializedFeatureToggle = SerializedFeatureToggle;
            
            // Act
            var deserialized = serializer.Deserialize(serializedFeatureToggle);

            // Assert
            // TODO: Assert correctly. Provide GetHashCode, Equals methods to condition classes and FeatureToggle class
        }
        
        private static readonly string SerializedFeatureToggle = @"{
  ""$type"": ""FeatureToggleService.Models.FeatureToggle, FeatureToggleService"",
  ""FeatureName"": ""MyFeature"",
  ""Condition"": {
    ""$type"": ""FeatureToggleService.Conditions.OrCondition, FeatureToggleService"",
    ""Left"": {
      ""$type"": ""FeatureToggleService.Conditions.SimpleCondition, FeatureToggleService"",
      ""Condition"": true
    },
    ""Right"": {
      ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
      ""Left"": {
        ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
        ""Left"": {
          ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
          ""Left"": {
            ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
            ""Left"": {
              ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
              ""Left"": {
                ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
                ""Left"": {
                  ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
                  ""Left"": {
                    ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
                    ""Left"": {
                      ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
                      ""Left"": {
                        ""$type"": ""FeatureToggleService.Conditions.AndCondition, FeatureToggleService"",
                        ""Left"": {
                          ""$type"": ""FeatureToggleService.Conditions.FromDateTimeCondition, FeatureToggleService"",
                          ""FromDateTime"": ""2019-05-16T15:00:00Z""
                        },
                        ""Right"": {
                          ""$type"": ""FeatureToggleService.Conditions.UntilDateTimeCondition, FeatureToggleService"",
                          ""UntilDateTime"": ""2019-05-17T15:00:00Z""
                        }
                      },
                      ""Right"": {
                        ""$type"": ""FeatureToggleService.Conditions.NegateCondition, FeatureToggleService""
                      }
                    },
                    ""Right"": {
                      ""$type"": ""FeatureToggleService.Conditions.NegateCondition, FeatureToggleService""
                    }
                  },
                  ""Right"": {
                    ""$type"": ""FeatureToggleService.Conditions.NegateCondition, FeatureToggleService""
                  }
                },
                ""Right"": {
                  ""$type"": ""FeatureToggleService.Conditions.DayOfWeekCollectionCondition, FeatureToggleService"",
                  ""DaysOfWeek"": {
                    ""$type"": ""System.DayOfWeek[], System.Private.CoreLib"",
                    ""$values"": [
                      1,
                      2,
                      4,
                      5,
                      6,
                      0
                    ]
    }
}
              },
              ""Right"": {
                ""$type"": ""FeatureToggleService.Conditions.InstallationCondition, FeatureToggleService"",
                ""Installation"": ""SAMPLE_INSTALLATION#1""
              }
            },
            ""Right"": {
              ""$type"": ""FeatureToggleService.Conditions.UserCondition, FeatureToggleService"",
              ""User"": ""USER#1""
            }
          },
          ""Right"": {
            ""$type"": ""FeatureToggleService.Conditions.NegateCondition, FeatureToggleService""
          }
        },
        ""Right"": {
          ""$type"": ""FeatureToggleService.Conditions.FromTimeOfDayCondition, FeatureToggleService"",
          ""FromTimeOfDay"": ""15:00:00""
        }
      },
      ""Right"": {
        ""$type"": ""FeatureToggleService.Conditions.UntilTimeOfDayCondition, FeatureToggleService"",
        ""UntilTimeOfDay"": ""16:00:00""
      }
    }
  }
}";

    }
}
