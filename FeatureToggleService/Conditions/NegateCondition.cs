using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public sealed class NegateCondition : Condition {
        private readonly Condition Condition;

        public NegateCondition(Condition condition) {
            Condition = condition;
        }

        public override bool Holds(Context context) {
            return !Condition.Holds(context);
        }
    }
}
