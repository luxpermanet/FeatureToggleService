using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FeatureToggleService.Serializers;
using FeatureToggleService.StorageProviders;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeatureToggleService.Controllers
{
    [Route("api/[controller]")]
    public class FeatureToggleController : Controller
    {
        private static readonly string FeatureToggleFilesPath = @"C:\Users\ERGO\Source\Repos\FeatureToggleService\FeatureToggleService\FeatureToggleFiles";
        private static readonly IStorageProvider storage = new JsonFileStorageProvider(FeatureToggleFilesPath);

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
        public ActionResult Post([FromBody]SerializedFeatureToggle serializedFeatureToggle)
        {
            try
            {
                // This is to validate the model. If the model is not valid deserialization will fail.
                FeatureToggleSerializer.Deserialize(serializedFeatureToggle);
            }
            catch (Exception)
            {
                // TODO: log the request here maybe, beware ddos
                return BadRequest();
            }
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
            var featureToggle = FeatureToggleSerializer.Deserialize(serializedFeatureToggle);
            featureToggle.InjectContext(DateTime.UtcNow, user, installation);
            return Ok(featureToggle.FeatureEnabled);
        }
    }
}
