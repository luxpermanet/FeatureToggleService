using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleIncludedInstallations : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (Installation == null) { throw new ArgumentNullException(nameof(Installation)); }

                return IncludedInstallations.Length == 0 || IncludedInstallations.Contains(Installation);
            }
        }
        
        public readonly string[] IncludedInstallations;
 
        public FeatureToggleIncludedInstallations(params string[] includedInstallations)
        {
            if (includedInstallations == null || includedInstallations.Length == 0) { throw new ArgumentNullException(nameof(includedInstallations)); }

            IncludedInstallations = includedInstallations;
        }
    }
}
