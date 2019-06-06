using System;

namespace FeatureToggles.Models
{
    public class FeatureToggleTimeOfDayInterval : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (!Now.HasValue) { throw new ArgumentNullException(nameof(Now)); }

                return 
                    (!TimeOfDayIntervalBegin.HasValue || TimeOfDayIntervalBegin <= Now.Value.TimeOfDay) && 
                    (!TimeOfDayIntervalEnd.HasValue || Now.Value.TimeOfDay <= TimeOfDayIntervalEnd);
            }
        }
        
        public readonly TimeSpan? TimeOfDayIntervalBegin;
        public readonly TimeSpan? TimeOfDayIntervalEnd;

        public FeatureToggleTimeOfDayInterval(TimeSpan? intervalBegin, TimeSpan? intervalEnd)
        {
            if (intervalBegin.HasValue && intervalEnd.HasValue && intervalBegin > intervalEnd) { throw new ArgumentException($"{nameof(intervalBegin)} cannot be greater than {nameof(intervalEnd)}"); }

            TimeOfDayIntervalBegin = intervalBegin;
            TimeOfDayIntervalEnd = intervalEnd;
        }
    }
}
