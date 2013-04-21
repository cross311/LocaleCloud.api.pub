using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/permissions", "GET", Summary = "Get all permissions meeting filters.")]
    [Route("/apps/{AppName}/permissions", "GET", Summary = "Get all permissions by app.")]
    [Route("/users/{Username}/permissions", "GET", Summary = "Get all permissions assigned to user.")]
    public class Permissions : IReturn<List<Permission>>
    {
        [ApiMember(Name = "Username", Description = "Filter param: for user's permissions.", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        [ApiMember(Name = "AppName", Description = "Filter param: for app's permissions.", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        public bool IsUsersByAppRequest()
        {
            return !string.IsNullOrWhiteSpace(this.Username) && !string.IsNullOrWhiteSpace(this.AppName);
        }

        public bool IsUsersRequest()
        {
            return !string.IsNullOrWhiteSpace(this.Username) && string.IsNullOrWhiteSpace(this.AppName);
        }

        public bool IsAppsRequest()
        {
            return !string.IsNullOrWhiteSpace(this.AppName) && string.IsNullOrWhiteSpace(this.Username);
        }
    }

    [Route("/permissions/{PermissionType}", "PUT", Summary = "Assign permissions to user for app.")]
    [Route("/permissions/{PermissionType}", "DELETE", Summary = "Unassign permissions from user for app.")]
    [Route("/apps/{AppName}/users/{Username}/permissions/{PermissionType}", "PUT", Summary = "Assign permissions to user for app.")]
    [Route("/apps/{AppName}/users/{Username}/permissions/{PermissionType}", "DELETE", Summary = "Unassign permissions from user for app.")]
    public class ModifyPermissions : IReturnVoid
    {
        [ApiMember(Name = "PermissionType", Description = "Email of user to give permission.  Use if don't know if user is registered already or not.", IsRequired = true, ParameterType = "path")]
        public PermissionType PermissionType { get; set; }

        [ApiMember(Name = "AppName", Description = "App to  assign or unassign user permission.", IsRequired = true, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "Username", Description = "User to assign or unassign permission.", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        [ApiMember(Name = "Email", Description = "Email of user to assign permission.  Use if don't know if user is registered already or not.", IsRequired = false, ParameterType = "path", Verb="PUT")]
        public string Email { get; set; }

        public bool IsByUsername()
        {
            return !string.IsNullOrWhiteSpace(this.Username) && string.IsNullOrWhiteSpace(this.Email);
        }

        public bool IsByEmail()
        {
            return !string.IsNullOrWhiteSpace(this.Email) && string.IsNullOrWhiteSpace(this.Username);
        }
    }
}
