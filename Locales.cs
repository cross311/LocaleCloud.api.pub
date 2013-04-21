using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/locales", "GET", Summary = "Gets static list of all supported locales for LocaleCloud.")]
    [Route("/apps/{AppName}/locales", "GET", Summary = "Get app supported locales.")]
    [Route("/users/{Username}/locales", "GET", Summary = "Get user supported locales.")]
    public class Locales : IReturn<List<Locale>>
    {

        [ApiMember(Name = "AppName", Description = "Filter param: for app's supported locales", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "Username", Description = "Filter param: for user's supported locales", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        public bool IsAppsRequest()
        {
            return !string.IsNullOrWhiteSpace(this.AppName);
        }

        public bool IsUserRequest()
        {
            return !string.IsNullOrWhiteSpace(this.Username);
        }
    }

    [Route("/locales", "PUT", Summary = "Adds locale support")]
    [Route("/locales", "DELETE", Summary = "Removes locale support.")]
    [Route("/apps/{AppName}/locales/{Locale}", "PUT", Summary = "Adds locale support to app.")]
    [Route("/apps/{AppName}/locales/{Locale}", "DELETE", Summary = "Removes locale support from app.")]
    [Route("/users/{Username}/locales/{Locale}", "PUT", Summary = "Adds locale support to user.")]
    [Route("/users/{Username}/locales/{Locale}", "DELETE", Summary = "Removes locale support from user.")]
    public class UpdateLocaleSupport : IReturnVoid
    {

        [ApiMember(Name = "Locale", Description = "The supported locale to add or remove ( 2-5 char locale code (en-us))", IsRequired = true, ParameterType = "path")]
        public string Locale { get; set; }

        [ApiMember(Name = "AppName", Description = "Required param to add or remove an app's supported locale", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "Username", Description = "Required param to add or remove an user's supported locale", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        public bool IsAppsRequest()
        {
            return !string.IsNullOrWhiteSpace(this.AppName);
        }

        public bool IsUserRequest()
        {
            return !string.IsNullOrWhiteSpace(this.Username);
        }
    }
}
