using System;

namespace FeatureToggleService.Misc
{
    public class Context {
        public DateTime? Now { get; }
        public string User { get; }
        public string Installation { get; }

        public Context(DateTime? now, string user, string installation) {
            Now = now;
            User = user;
            Installation = installation;
        }
    }
}
