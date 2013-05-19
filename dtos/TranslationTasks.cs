using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/translationTasks", "GET", Summary = "Get all translation tasks meeting filters.")]
    [Route("/apps/{AppName}/translationTasks", "GET", Summary = "Get all translation tasks unassigned by app.")]
    [Route("/users/{Username}/translationTasks", "GET", Summary = "Get all translation tasks assigned to user.")]
    public class TranslationTasks : IReturn<List<TranslationTask>>
    {
        [ApiMember(Name = "Username", Description = "Filter param: for user's translation tasks.", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        [ApiMember(Name = "AppName", Description = "Filter param: for app's translation tasks.", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "Locales", Description = "Filter param: translation tasks for locale (2-5 char locale code (en-us))", IsRequired = false, ParameterType = "path", AllowMultiple = true)]
        public string Locales { get; set; }

        public bool IsUnassignedByApp()
        {
            return !string.IsNullOrWhiteSpace(AppName) && string.IsNullOrWhiteSpace(Username) && string.IsNullOrWhiteSpace(Locales);
        }

        public bool IsUnassignedByAppAndLocales()
        {
            return !string.IsNullOrWhiteSpace(AppName) && string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Locales);
        }

        public bool IsAssignedByApp()
        {
            return !string.IsNullOrWhiteSpace(AppName) && !string.IsNullOrWhiteSpace(Username) && string.IsNullOrWhiteSpace(Locales);
        }

        public bool IsAssignedByAppAndLocales()
        {
            return !string.IsNullOrWhiteSpace(AppName) && !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Locales);
        }

        public bool IsAllAssigned()
        {
            return string.IsNullOrWhiteSpace(AppName) && !string.IsNullOrWhiteSpace(Username) && string.IsNullOrWhiteSpace(Locales);
        }
    }

    [Route("/translationTasks/{TaskId}", "PUT", Summary = "Assign task to user.")]
    [Route("/translationTasks/{TaskId}", "DELETE", Summary = "Unassign task from user.")]
    [Route("/users/{Username}/translationTasks/{TaskId}", "PUT", Summary = "Assign task to user.")]
    [Route("/users/{Username}/translationTasks/{TaskId}", "DELETE", Summary = "Unassign task from user.")]
    public class ModifyTranslationTaskAssignment : IReturnVoid
    {
        [ApiMember(Name = "TaskId", Description = "Required param: task id of task to assign or unassign.", IsRequired = true, ParameterType = "path")]
        public long TaskId { get; set; }

        [ApiMember(Name = "Username", Description = "Filter param: user id of task to assign or unassign", IsRequired = true, ParameterType = "path", Verb = "PUT")]
        public string Username { get; set; }
    }
}
