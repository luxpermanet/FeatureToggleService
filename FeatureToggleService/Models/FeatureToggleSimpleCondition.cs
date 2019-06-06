namespace FeatureToggles.Models
{
    public class FeatureToggleSimpleCondition : FeatureToggleBase
    {
        public override bool FeatureEnabled => Condition;
        
        public readonly bool Condition;

        public FeatureToggleSimpleCondition(bool condition)
        {
            Condition = condition;
        }
    }
}
