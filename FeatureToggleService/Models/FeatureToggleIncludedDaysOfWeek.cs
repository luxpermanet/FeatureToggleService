using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleIncludedDaysOfWeek : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (!Now.HasValue) { throw new ArgumentNullException(nameof(Now)); }

                return IncludedDaysOfWeek.Length == 0 || IncludedDaysOfWeek.Contains(Now.Value.DayOfWeek);
            }
        }
        
        public readonly DayOfWeek[] IncludedDaysOfWeek;
        
        public FeatureToggleIncludedDaysOfWeek(params DayOfWeek[] includedDaysOfWeek)
        {
            if (includedDaysOfWeek == null || includedDaysOfWeek.Length == 0) { throw new ArgumentNullException(nameof(includedDaysOfWeek)); }

            IncludedDaysOfWeek = includedDaysOfWeek;
        }
    }
}
