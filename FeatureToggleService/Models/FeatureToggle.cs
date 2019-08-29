using FeatureToggleService.Conditions;

namespace FeatureToggleService.Models
{
    public class FeatureToggle
    {
        public string FeatureName;
        public Condition Condition;
    }
}
