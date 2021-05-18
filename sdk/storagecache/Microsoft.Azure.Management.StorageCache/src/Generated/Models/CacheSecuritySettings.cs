// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.StorageCache.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Cache security settings.
    /// </summary>
    public partial class CacheSecuritySettings
    {
        /// <summary>
        /// Initializes a new instance of the CacheSecuritySettings class.
        /// </summary>
        public CacheSecuritySettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CacheSecuritySettings class.
        /// </summary>
        /// <param name="accessPolicies">NFS access policies defined for this
        /// cache.</param>
        public CacheSecuritySettings(IList<NfsAccessPolicy> accessPolicies = default(IList<NfsAccessPolicy>))
        {
            AccessPolicies = accessPolicies;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets NFS access policies defined for this cache.
        /// </summary>
        [JsonProperty(PropertyName = "accessPolicies")]
        public IList<NfsAccessPolicy> AccessPolicies { get; set; }

    }
}
