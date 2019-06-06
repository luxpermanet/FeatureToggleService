using System;

namespace FeatureToggleService.Serializers
{
    public class SerializedFeatureToggleEntity
    {
        public DateTime? DateTimeIntervalBegin;
        public DateTime? DateTimeIntervalEnd;
        public string ExcludedDaysOfWeek;
        public string ExcludedInstallations;
        public string ExcludedUsers;
        public string IncludedDaysOfWeek;
        public string IncludedInstallations;
        public string IncludedUsers;
        public bool? Condition;
        public TimeSpan? TimeOfDayIntervalBegin;
        public TimeSpan? TimeOfDayIntervalEnd;
    }
}
