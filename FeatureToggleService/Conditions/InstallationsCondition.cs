using FeatureToggleService.Misc;
using System;
using System.Linq;

namespace FeatureToggleService.Conditions
{
    public class InstallationsCondition : Condition
    {
        public readonly string[] Installations;

        public InstallationsCondition(params string[] installations)
        {
            if (installations == null || installations.Length == 0) { throw new ArgumentNullException(nameof(installations)); }

            Installations = installations;
        }

        public override bool Holds(Context context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.Installation == null) { throw new ArgumentNullException(nameof(context.Installation)); }

            return Installations.Contains(context.Installation);
        }
    }
}
