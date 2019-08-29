using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public class SimpleCondition : Condition {
        public readonly bool Condition;

        public SimpleCondition(bool condition) {
            Condition = condition;
        }

        public override bool Holds(Context context) {
            return Condition;
        }
    }
}
