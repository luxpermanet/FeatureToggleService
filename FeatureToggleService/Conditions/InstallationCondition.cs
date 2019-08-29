using FeatureToggleService.Misc;
using System;

namespace FeatureToggleService.Conditions {
    public class InstallationCondition : Condition {
        public readonly string Installation;

        public InstallationCondition(string installation) {
            if (string.IsNullOrEmpty(installation)) { throw new ArgumentNullException(nameof(installation)); }

            Installation = installation;
        }

        public override bool Holds(Context context) {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.Installation == null) { throw new ArgumentNullException(nameof(context.Installation)); }

            return Installation == context.Installation;
        }
    }
}
