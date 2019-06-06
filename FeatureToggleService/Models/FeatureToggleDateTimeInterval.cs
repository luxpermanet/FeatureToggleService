using System;

namespace FeatureToggles.Models
{
    public class FeatureToggleDateTimeInterval : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (!Now.HasValue) { throw new ArgumentNullException(nameof(Now)); }

                return 
                    (!DateTimeIntervalBegin.HasValue || DateTimeIntervalBegin <= Now) && 
                    (!DateTimeIntervalEnd.HasValue || Now <= DateTimeIntervalEnd);
            }
        }
        
        public readonly DateTime? DateTimeIntervalBegin;
        public readonly DateTime? DateTimeIntervalEnd;

        public FeatureToggleDateTimeInterval(DateTime? intervalBegin, DateTime? intervalEnd)
        {
            if (intervalBegin.HasValue && intervalEnd.HasValue && intervalBegin > intervalEnd) { throw new ArgumentException($"{nameof(intervalBegin)} cannot be greater than {nameof(intervalEnd)}"); }

            DateTimeIntervalBegin = intervalBegin;
            DateTimeIntervalEnd = intervalEnd;
        }
    }
}
