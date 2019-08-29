using FeatureToggleService.Misc;
using System;

namespace FeatureToggleService.Conditions {
    public class UntilTimeOfDayCondition : Condition {
        public readonly TimeSpan UntilTimeOfDay;

        public UntilTimeOfDayCondition(TimeSpan untilTimeOfDay) {
            UntilTimeOfDay = untilTimeOfDay;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return context.Now.Value.TimeOfDay <= UntilTimeOfDay;
        }
    }
}
