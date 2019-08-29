using FeatureToggleService.Misc;
using System;

namespace FeatureToggleService.Conditions {
    public sealed class AndCondition : Condition {
        public Condition Left;
        public Condition Right;

        public AndCondition(Condition left, Condition right) {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override bool Holds(Context context) {
            return Left.Holds(context) && Right.Holds(context);
        }
    }
}
