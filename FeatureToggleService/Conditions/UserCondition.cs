using FeatureToggleService.Misc;
using System;

namespace FeatureToggleService.Conditions {
    public class UserCondition : Condition {
        public readonly string User;

        public UserCondition(string user) {
            if (string.IsNullOrEmpty(user)) { throw new ArgumentNullException(nameof(user)); }

            User = user;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.User == null) { throw new ArgumentNullException(nameof(context.User)); }

            return User == context.User;
        }
    }
}
