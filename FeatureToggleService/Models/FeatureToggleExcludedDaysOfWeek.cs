using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleExcludedDaysOfWeek : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (!Now.HasValue) { throw new ArgumentNullException(nameof(Now)); }

                return !ExcludedDaysOfWeek.Contains(Now.Value.DayOfWeek);
            }
        }
        
        public readonly DayOfWeek[] ExcludedDaysOfWeek;
        
        public FeatureToggleExcludedDaysOfWeek(params DayOfWeek[] excludedDaysOfWeek)
        {
            if (excludedDaysOfWeek == null || excludedDaysOfWeek.Length == 0) { throw new ArgumentNullException(nameof(excludedDaysOfWeek)); }

            ExcludedDaysOfWeek = excludedDaysOfWeek;
        }
    }
}
