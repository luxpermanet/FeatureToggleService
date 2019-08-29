using System;
using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public class FromTimeOfDayCondition : Condition {
        public readonly TimeSpan FromTimeOfDay;

        public FromTimeOfDayCondition(TimeSpan fromTimeOfDay) {
            FromTimeOfDay = fromTimeOfDay;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return FromTimeOfDay <= context.Now.Value.TimeOfDay;
        }
    }
}
