using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/releases", "GET", Summary = "Get all releases meeting filter criteria.")]
    [Route("/apps/{AppName}/releases", "GET", Summary = "Get all releases in app.")]
    [Route("/apps/{AppName}/releases/{ReleaseName*}", "GET", Summary = "Get single release with matching name in app.")]
    public class Releases : IReturn<List<Release>>
    {
        [ApiMember(Name = "AppName", Description = "Filter param: for app's releases", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName*", Description = "Filter param: single app's release", IsRequired = false, ParameterType = "path")]
        public string ReleaseName { get; set; }

        public bool IsByApplicationRequest()
        {
            return !string.IsNullOrEmpty(AppName) && string.IsNullOrEmpty(ReleaseName);
        }

        public bool IsSingleRequest()
        {
            return !string.IsNullOrEmpty(AppName) && !string.IsNullOrEmpty(ReleaseName);
        }
    }

    [Route("/releases", "PUT", Summary = "Create release on app. If order empty will be most recent release.")]
    [Route("/releases", "POST", Summary = "Update release information.")]
    [Route("/releases", "DELETE", Summary = "Remove release from app, only if it has no associated tokens.")]
    [Route("/apps/{AppName}/releases", "PUT", Summary = "Create release on app. If order empty will be most recent release.")]
    [Route("/apps/{AppName}/releases/{ReleaseName*}", "POST", Summary = "Reorder release.")]
    [Route("/apps/{AppName}/releases/{ReleaseName*}", "DELETE", Summary = "Remove release from app, only if it has no associated tokens.")]
    public class UpdateRelease : IReturnVoid
    {
        [ApiMember(Name = "AppName", Description = "Required param to add or update an app's release", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "The release name to add or update", IsRequired = true, ParameterType = "query", Verb = "PUT")]
        [ApiMember(Name = "ReleaseName*", Description = "The release name to add or update", IsRequired = true, ParameterType = "path", Verb = "POST")]
        [ApiMember(Name = "ReleaseName*", Description = "The release name to add or update", IsRequired = true, ParameterType = "path", Verb = "DELETE")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "Order", Description = "The order this release relates to other releases in app.", IsRequired = false, ParameterType = "query", Verb = "PUT")]
        [ApiMember(Name = "Order", Description = "The order this release relates to other releases in app.", IsRequired = true, ParameterType = "query", Verb = "POST")]
        public int Order { get; set; }
    }
}
