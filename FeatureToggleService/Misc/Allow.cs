using FeatureToggleService.Conditions;
using System;

namespace FeatureToggleService.Misc
{
    public static class Allow {
        public static Condition Simple()
        {
            return new SimpleCondition(true);
        }

        public static Condition DayOfWeek(DayOfWeek dayOfWeek) {
            return new DayOfWeekCondition(dayOfWeek);
        }

        public static Condition FromDateTime(DateTime fromDateTime) {
            return new FromDateTimeCondition(fromDateTime);
        }

        public static Condition FromTimeOfDay(TimeSpan fromTimeOfDay) {
            return new FromTimeOfDayCondition(fromTimeOfDay);
        }

        public static Condition Installation(string installation) {
            return new InstallationCondition(installation);
        }

        public static Condition UntilDateTime(DateTime untilDateTime) {
            return new UntilDateTimeCondition(untilDateTime);
        }

        public static Condition UntilTimeOfDay(TimeSpan untilTimeOfDay) {
            return new UntilTimeOfDayCondition(untilTimeOfDay);
        }

        public static Condition User(string user) {
            return new UserCondition(user);
        }

        public static Condition Users(params string[] users)
        {
            return new UserCollectionCondition(users);
        }

        public static Condition Installations(params string[] installations)
        {
            return new InstallationCollectionCondition(installations);
        }

        public static Condition DaysOfWeek(params DayOfWeek[] daysOfWeek)
        {
            return new DayOfWeekCollectionCondition(daysOfWeek);
        }
    }
}
