using System;
using System.Linq;

namespace FeatureToggles.Models
{
    public class FeatureToggleIncludedUsers : FeatureToggleBase
    {
        public override bool FeatureEnabled {
            get {
                if (User == null) { throw new ArgumentNullException(nameof(User)); }

                return IncludedUsers.Length == 0 || IncludedUsers.Contains(User);
            }
        }
        
        public readonly string[] IncludedUsers;
 
        public FeatureToggleIncludedUsers(params string[] includedUsers)
        {
            if (includedUsers == null || includedUsers.Length == 0) { throw new ArgumentNullException(nameof(includedUsers)); }

            IncludedUsers = includedUsers;
        }
    }
}
