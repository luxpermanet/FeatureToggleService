using System;
using FeatureToggleService.Misc;
using FeatureToggleService.Models;
using FeatureToggleService.StorageProviders;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggleService.Controllers
{
    [Route("api/[controller]")]
    public class FeatureToggleController : Controller
    {
        private static readonly string FeatureToggleFolderPath = @"C:\Users\ERGO\Source\Repos\FeatureToggleService\FeatureToggleService\FeatureToggleFiles";
        private static readonly IStorageProvider storage = new JsonFileStorageProvider(FeatureToggleFolderPath);

        // GET api/featuretoggle
        [HttpGet]
        public ActionResult Get()
        {
            var featureToggleNames = storage.GetFeatureToggleNames();
            return Ok(featureToggleNames);
        }

        // GET api/featuretoggle/runinbackground
        [HttpGet("{featureName}")]
        public ActionResult Get(string featureName)
        {
            if (!storage.HasFeatureToggle(featureName)) {
                return NotFound();
            }
            return Ok(storage.GetFeatureToggle(featureName));
        }

        // POST api/featuretoggle
        [HttpPost]
        public ActionResult Post([FromBody]FeatureToggle serializedFeatureToggle)
        {
            storage.SaveFeatureToggle(serializedFeatureToggle);
            return Ok();
        }

        // DELETE api/featuretoggle/runinbackground
        [HttpDelete("{featureName}")]
        public ActionResult Delete(string featureName)
        {
            return Ok(storage.DeleteFeatureToggle(featureName));
        }

        // GET api/featuretoggle/ison/runinbackground/ergo/foartp
        [HttpGet("ison/{featureName}/{user}/{installation}")]
        public ActionResult IsOn(string featureName, string user, string installation)
        {
            var serializedFeatureToggle = storage.GetFeatureToggle(featureName);
            var context = new Context(DateTime.UtcNow, user, installation);
            var featureEnabled = serializedFeatureToggle.Condition.Holds(context);
            return Ok(featureEnabled);
        }
    }
}
