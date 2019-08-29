using FeatureToggleService.Conditions;
using System;

namespace FeatureToggleService.Misc
{
    public static class Allow
    {
        public static Condition Simple()
        {
            return new SimpleCondition(true);
        }

        public static Condition FromDateTime(DateTime fromDateTime)
        {
            return new FromDateTimeCondition(fromDateTime);
        }

        public static Condition FromTimeOfDay(TimeSpan fromTimeOfDay)
        {
            return new FromTimeOfDayCondition(fromTimeOfDay);
        }

        public static Condition UntilDateTime(DateTime untilDateTime)
        {
            return new UntilDateTimeCondition(untilDateTime);
        }

        public static Condition UntilTimeOfDay(TimeSpan untilTimeOfDay)
        {
            return new UntilTimeOfDayCondition(untilTimeOfDay);
        }

        public static Condition Users(params string[] users)
        {
            return new UsersCondition(users);
        }

        public static Condition Installations(params string[] installations)
        {
            return new InstallationsCondition(installations);
        }

        public static Condition DaysOfWeek(params DayOfWeek[] daysOfWeek)
        {
            return new DaysOfWeekCondition(daysOfWeek);
        }
    }
}
