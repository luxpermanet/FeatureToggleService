using System;

namespace FeatureToggles.Models
{
    public abstract class FeatureToggleBase
    {
        public abstract bool FeatureEnabled { get; }

        protected DateTime? Now;
        protected string User;
        protected string Installation;

        public virtual void InjectContext(DateTime? now, string user, string installation)
        {
            Now = now;
            User = user;
            Installation = installation;
        }
    }
}
