using System;
using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public class FromDateTimeCondition : Condition {
        public readonly DateTime FromDateTime;

        public FromDateTimeCondition(DateTime fromDateTime) {
            FromDateTime = fromDateTime;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return FromDateTime <= context.Now;
        }
    }
}
