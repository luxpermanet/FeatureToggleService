using FeatureToggleService.Conditions;
using System;

namespace FeatureToggleService.Misc
{
    public static class Restrict {
        public static Condition Simple()
        {
            return Allow.Simple().Negate();
        }

        public static Condition DayOfWeek(DayOfWeek dayOfWeek) {
            return Allow.DayOfWeek(dayOfWeek).Negate();
        }

        public static Condition FromDateTime(DateTime fromDateTime) {
            return Allow.FromDateTime(fromDateTime).Negate();
        }

        public static Condition FromTimeOfDay(TimeSpan fromTimeOfDay) {
            return Allow.FromTimeOfDay(fromTimeOfDay).Negate();
        }

        public static Condition Installation(string installation) {
            return Allow.Installation(installation).Negate();
        }

        public static Condition UntilDateTime(DateTime untilDateTime) {
            return Allow.UntilDateTime(untilDateTime).Negate();
        }

        public static Condition UntilTimeOfDay(TimeSpan untilTimeOfDay) {
            return Allow.UntilTimeOfDay(untilTimeOfDay).Negate();
        }

        public static Condition User(string user) {
            return Allow.User(user).Negate();
        }

        public static Condition Users(params string[] users)
        {
            return Allow.Users(users).Negate();
        }

        public static Condition Installations(params string[] installations)
        {
            return Allow.Installations(installations).Negate();
        }

        public static Condition DaysOfWeek(params DayOfWeek[] daysOfWeek)
        {
            return Allow.DaysOfWeek(daysOfWeek).Negate();
        }
    }
}
