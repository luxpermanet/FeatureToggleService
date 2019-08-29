using System;
using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public class DayOfWeekCondition : Condition {
        public readonly DayOfWeek DayOfWeek;

        public DayOfWeekCondition(DayOfWeek dayOfWeek) {
            DayOfWeek = dayOfWeek;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return DayOfWeek == context.Now.Value.DayOfWeek;
        }
    }
}
