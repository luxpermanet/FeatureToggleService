using FeatureToggleService.Misc;

namespace FeatureToggleService.Conditions {
    public abstract class Condition {
        public abstract bool Holds(Context context);

        public Condition And(Condition condition) {
            return new AndCondition(this, condition);
        }

        public Condition Or(Condition condition) {
            return new OrCondition(this, condition);
        }

        public Condition Negate() {
            return new NegateCondition(this);
        }
    }
}
