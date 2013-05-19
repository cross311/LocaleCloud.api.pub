using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/apps", "GET", Summary="Get all apps available to authenticated user.")]
    [Route("/apps/{AppName}", "GET", Summary = "Get app by name.")]
    public class Apps : IReturn<List<App>>
    {
        [ApiMember(Name = "AppName", Description = "Filter param: for single application", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        public bool IsAllRequest()
        {
            return this.AppName == default(string);
        }
    }

    [Api("Create or Update an App resource.")]
    [Route("/apps", "PUT", Summary="Create app.")]
    [Route("/apps", "POST", Summary="Update app.")]
    public class SaveApp : IReturnVoid
    {
        [ApiMember(Name = "AppName", Description = "App's name", IsRequired = true, ParameterType = "query")]
        public string AppName { get; set; }

        [ApiMember(Name = "BaseLocale", Description = "App's default locale. 2-5 char locale code (en-us). Must be in list of /locales", IsRequired = true, ParameterType = "query")]
        public string BaseLocale { get; set; }

        [ApiMember(Name = "AllowAutoCreate", Description = "Allow tokens to be automatically created for newest release. (true|false)", IsRequired = true, ParameterType = "query", DataType="bool")]
        public bool AllowAutoCreate { get; set; }


        [ApiMember(Name = "StartReleaseName", Description = "App's starting release name or number (e.x. 1.0.0)", IsRequired = true, ParameterType = "query", Verb = "PUT")]
        public string StartReleaseName { get; set; }
    }
}
