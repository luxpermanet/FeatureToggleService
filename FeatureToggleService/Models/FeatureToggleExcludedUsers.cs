using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleExcludedUsers : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (User == null) { throw new ArgumentNullException(nameof(User)); }

                return !ExcludedUsers.Contains(User);
            }
        }
        
        public readonly string[] ExcludedUsers;
 
        public FeatureToggleExcludedUsers(params string[] excludedUsers)
        {
            if (excludedUsers == null || excludedUsers.Length == 0) { throw new ArgumentNullException(nameof(excludedUsers)); }

            ExcludedUsers = excludedUsers;
        }
    }
}
