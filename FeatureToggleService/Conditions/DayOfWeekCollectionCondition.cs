using System;
using System.Linq;
using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions
{
    public class DayOfWeekCollectionCondition : Condition
    {
        public readonly DayOfWeek[] DaysOfWeek;

        public DayOfWeekCollectionCondition(params DayOfWeek[] daysOfWeek)
        {
            if (daysOfWeek == null || daysOfWeek.Length == 0) { throw new ArgumentNullException(nameof(daysOfWeek)); }

            DaysOfWeek = daysOfWeek;
        }

        public override bool Holds(Context context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (!context.Now.HasValue) { throw new ArgumentNullException(nameof(context.Now)); }

            return DaysOfWeek.Contains(context.Now.Value.DayOfWeek);
        }
    }
}
