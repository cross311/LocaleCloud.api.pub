using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/tokens", "GET", Summary = "Get all tokens meeting parameters.")]
    [Route("/apps/{AppName}/tokens", "GET", Summary = "Get all tokens for app and release.")]
    [Route("/apps/{AppName}/locales/{Locale}/tokens", "GET", Summary = "Get all token translation pairs for app's release and locale.")]
    public class Tokens : IReturn<Dictionary<string,string>>
    {
        [ApiMember(Name = "AppName", Description = "Required param: for app's tokens", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Required param: tokens in app's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "Locale", Description = "Filter param: fills in translations for locale ( 2-5 char locale code (en-us))", IsRequired = true, ParameterType = "path")]
        public string Locale { get; set; }
    }


    [Route("/apps/{AppName}/tokens/{TokenName}", "GET", Summary = "Get single tokens details.")]
    public class TokenDetails : IReturn<Token>
    {
        [ApiMember(Name = "AppName", Description = "Required param: token's app", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Required param: token's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "TokenName", Description = "Required param: token's name", IsRequired = true, ParameterType = "path")]
        public string TokenName { get; set; }
    }

    [Route("/tokens/{TokenName}", "PUT", Summary = "Creates a token starting at release. If already exists on older release will mark old as deleted.")]
    [Route("/tokens/{TokenName}", "DELETE", Summary = "Marks token as deleted for release and all newer ones. Will stil be available in older releases.")]
    [Route("/apps/{AppName}/tokens/{TokenName}", "PUT", Summary = "Creates a token starting at release. If already exists on older release will mark old as deleted.")]
    [Route("/apps/{AppName}/tokens/{TokenName}", "DELETE", Summary = "Marks token as deleted for release and all newer ones. Will stil be available in older releases.")]
    public class CreateDeleteTokenAtRelease : IReturnVoid
    {
        [ApiMember(Name = "AppName", Description = "Required param: token's app", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Required param: token's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "TokenName", Description = "Required param: token's name", IsRequired = true, ParameterType = "path")]
        public string TokenName { get; set; }
    }

    [Route("/tokens", "POST", Summary = "Update translations for app's release for locale.")]
    [Route("/apps/{AppName}/locales/{Locale}/tokens", "POST", Summary = "Update translations for app's release for locale.")]
    public class UpdateTranslation : IReturnVoid
    {
        [ApiMember(Name = "AppName", Description = "Required param: for app's tokens", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "ReleaseName", Description = "Required param: tokens in app's release", IsRequired = true, ParameterType = "query")]
        public string ReleaseName { get; set; }

        [ApiMember(Name = "Locale", Description = "Required param: fills in translations for locale ( 2-5 char locale code (en-us))", IsRequired = true, ParameterType = "path")]
        public string Locale { get; set; }

        [ApiMember(Name = "TokenName ", Description = "Single param: token name, if just translating one", IsRequired = false, ParameterType = "path")]
        public string TokenName { get; set; }

        [ApiMember(Name = "Translation", Description = "Single param: translation, if just translating one", IsRequired = false, ParameterType = "path")]
        public string Translation { get; set; }

        [ApiMember(Name = "Translations", Description = "multi param: Dictionary of batch translations. e.x. key value pair {'tokenName':'translation'}", IsRequired = false, ParameterType = "body")]
        public Dictionary<string,string> Translations { get; set; }

        public bool IsMulti()
        {
            return this.Translations != null && string.IsNullOrWhiteSpace(this.TokenName);
        }

        public bool IsSingle()
        {
            return !string.IsNullOrWhiteSpace(this.TokenName) && !string.IsNullOrWhiteSpace(this.Translation) && this.Translations == null;
        }
    }
}
