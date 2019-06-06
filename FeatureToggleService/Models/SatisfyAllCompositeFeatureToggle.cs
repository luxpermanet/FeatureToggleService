using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class SatisfyAllCompositeFeatureToggle : FeatureToggleBase
    {
        public readonly FeatureToggleBase[] AllShallPass;
        
        public override bool FeatureEnabled => AllShallPass.All(featureToggle => featureToggle.FeatureEnabled);
        
        public SatisfyAllCompositeFeatureToggle(params FeatureToggleBase[] featureToggles)
        {
            if (featureToggles == null || featureToggles.Length == 0) { throw new ArgumentNullException(nameof(featureToggles)); }

            AllShallPass = featureToggles;
        }

        public override void InjectContext(DateTime? now, string user, string installation)
        {
            foreach (var featureToggle in AllShallPass)
            {
                featureToggle.InjectContext(now, user, installation);
            }
        }
    }
}
