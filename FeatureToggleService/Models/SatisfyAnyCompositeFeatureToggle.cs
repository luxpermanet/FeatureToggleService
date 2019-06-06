using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class SatisfyAnyCompositeFeatureToggle : FeatureToggleBase
    {
        public readonly FeatureToggleBase[] AnyShallPass;

        public override bool FeatureEnabled => AnyShallPass.Any(featureToggle => featureToggle.FeatureEnabled);

        public SatisfyAnyCompositeFeatureToggle(params FeatureToggleBase[] featureToggles)
        {
            if (featureToggles == null || featureToggles.Length == 0) { throw new ArgumentNullException(nameof(featureToggles)); }

            AnyShallPass = featureToggles;
        }

        public override void InjectContext(DateTime? now, string user, string installation)
        {
            foreach (var featureToggle in AnyShallPass)
            {
                featureToggle.InjectContext(now, user, installation);
            }
        }
    }
}
