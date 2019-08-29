using FeatureToggleService.Misc;
using System;

namespace FeatureToggleService.Conditions {
    public class UntilDateTimeCondition : Condition {
        public readonly DateTime UntilDateTime;

        public UntilDateTimeCondition(DateTime untilDateTime) {
            UntilDateTime = untilDateTime;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return context.Now <= UntilDateTime;
        }
    }
}
