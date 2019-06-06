using FeatureToggles.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureToggleService.Serializers
{
    public static class FeatureToggleSerializer
    {
        private const char ListDelimiter = ';';
        
        public static FeatureToggleBase Deserialize(SerializedFeatureToggle serialized) {
            if (serialized.SerializedFeatureToggleEntities == null) {
                throw new ArgumentNullException($"{nameof(serialized.SerializedFeatureToggleEntities)}");
            }

            var satisfyAnyComponents = new List<FeatureToggleBase>();
            foreach (var entity in serialized.SerializedFeatureToggleEntities)
            {
                satisfyAnyComponents.Add(DeserializeEntity(entity));
            }

            var satisfyAnyComponentsArray = satisfyAnyComponents.ToArray();
            if (satisfyAnyComponentsArray.Length == 0)
            {
                throw new Exception("SerializedFeatureToggle was not set up correctly");
            }

            if (satisfyAnyComponentsArray.Length == 1)
            {
                return satisfyAnyComponentsArray.Single();
            }

            return new SatisfyAnyCompositeFeatureToggle(satisfyAnyComponentsArray);
        }

        private static FeatureToggleBase DeserializeEntity(SerializedFeatureToggleEntity entity) {
            var satisfyAllComponents = new List<FeatureToggleBase>();
            if (entity.Condition.HasValue)
            {
                satisfyAllComponents.Add(new FeatureToggleSimpleCondition(entity.Condition.Value));
            }
            if (entity.DateTimeIntervalBegin.HasValue || entity.DateTimeIntervalEnd.HasValue)
            {
                satisfyAllComponents.Add(new FeatureToggleDateTimeInterval(entity.DateTimeIntervalBegin, entity.DateTimeIntervalEnd));
            }
            if (!string.IsNullOrWhiteSpace(entity.ExcludedDaysOfWeek))
            {
                var excludedDaysOfWeek = entity.ExcludedDaysOfWeek.Split(ListDelimiter).Select(excludedDayOfWeek => Enum.Parse<DayOfWeek>(excludedDayOfWeek)).ToArray();
                satisfyAllComponents.Add(new FeatureToggleExcludedDaysOfWeek(excludedDaysOfWeek));
            }
            if (!string.IsNullOrWhiteSpace(entity.ExcludedInstallations))
            {
                var excludedInstallations = entity.ExcludedInstallations.Split(ListDelimiter);
                satisfyAllComponents.Add(new FeatureToggleExcludedInstallations(excludedInstallations));
            }
            if (!string.IsNullOrWhiteSpace(entity.ExcludedUsers))
            {
                var excludedUsers = entity.ExcludedUsers.Split(ListDelimiter);
                satisfyAllComponents.Add(new FeatureToggleExcludedUsers(excludedUsers));
            }
            if (!string.IsNullOrWhiteSpace(entity.IncludedDaysOfWeek))
            {
                var includedDaysOfWeek = entity.IncludedDaysOfWeek.Split(ListDelimiter).Select(includedDayOfWeek => Enum.Parse<DayOfWeek>(includedDayOfWeek)).ToArray();
                satisfyAllComponents.Add(new FeatureToggleIncludedDaysOfWeek(includedDaysOfWeek));
            }
            if (!string.IsNullOrWhiteSpace(entity.IncludedInstallations))
            {
                var includedInstallations = entity.IncludedInstallations.Split(ListDelimiter);
                satisfyAllComponents.Add(new FeatureToggleIncludedInstallations(includedInstallations));
            }
            if (!string.IsNullOrWhiteSpace(entity.IncludedUsers))
            {
                var includedUsers = entity.IncludedUsers.Split(ListDelimiter);
                satisfyAllComponents.Add(new FeatureToggleIncludedUsers(includedUsers));
            }
            if (entity.TimeOfDayIntervalBegin.HasValue || entity.TimeOfDayIntervalEnd.HasValue)
            {
                satisfyAllComponents.Add(new FeatureToggleTimeOfDayInterval(entity.TimeOfDayIntervalBegin, entity.TimeOfDayIntervalEnd));
            }

            var satisfyAllComponentsArray = satisfyAllComponents.ToArray();
            if (satisfyAllComponentsArray.Length == 0) {
                throw new Exception("SerializedFeatureToggleEntity was not set up correctly");
            }

            if (satisfyAllComponentsArray.Length == 1) {
                return satisfyAllComponentsArray.Single();
            }

            return new SatisfyAllCompositeFeatureToggle(satisfyAllComponentsArray);
        }
    }
}
