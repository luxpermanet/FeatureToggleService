using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleExcludedInstallations : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (Installation == null) { throw new ArgumentNullException(nameof(Installation)); }

                return !ExcludedInstallations.Contains(Installation);
            }
        }
        
        public readonly string[] ExcludedInstallations;
 
        public FeatureToggleExcludedInstallations(params string[] excludedInstallations)
        {
            if (excludedInstallations == null || excludedInstallations.Length == 0) { throw new ArgumentNullException(nameof(excludedInstallations)); }

            ExcludedInstallations = excludedInstallations;
        }
    }
}
