using FeatureToggleService.Misc;
using System;
using System.Linq;

namespace FeatureToggleService.Conditions
{
    public class UserCollectionCondition : Condition
    {
        public readonly string[] Users;

        public UserCollectionCondition(params string[] users)
        {
            if (users == null || users.Length == 0) { throw new ArgumentNullException(nameof(users)); }

            Users = users;
        }

        public override bool Holds(Context context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.User == null) { throw new ArgumentNullException(nameof(context.User)); }

            return Users.Contains(context.User);
        }
    }
}
