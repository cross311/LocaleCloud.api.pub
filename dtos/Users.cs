using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;
using medidata.localeCloud.api.pub.dtos.models;

namespace medidata.localeCloud.api.pub.dtos
{
    [Route("/users", "GET", Summary="Get all users authenticated user can see.")]
    [Route("/users/{Username}", "GET", Summary="Get user by username.")]
    [Route("/apps/{AppName}/users", "GET", Summary="Get all users for app.")]
    [Route("/apps/{AppName}/locales/{locale}/users", "GET", Summary="Get all uses for app that have marked locales as supported.")]
    public class Users : IReturn<List<User>>
    {
        [ApiMember(Name = "Username", Description = "Filter param: for single user", IsRequired = false, ParameterType = "path")]
        public string Username { get; set; }

        [ApiMember(Name = "AppName", Description = "Filter param: for app's users", IsRequired = false, ParameterType = "path")]
        public string AppName { get; set; }

        [ApiMember(Name = "Locales", Description = "Filter param: users supporting locale (Comma Seperated List of  2-5 char locale code (en-us))", AllowMultiple = true, IsRequired = false, ParameterType = "path")]
        public string Locales { get; set; }

        public bool IsByApp()
        {
            return !string.IsNullOrWhiteSpace(this.AppName) && string.IsNullOrWhiteSpace(this.Locales) && string.IsNullOrWhiteSpace(this.Username);
        }

        public bool IsByAppAndLocales()
        {
            return !string.IsNullOrWhiteSpace(this.AppName) && !string.IsNullOrWhiteSpace(this.Locales) && string.IsNullOrWhiteSpace(this.Username);
        }

        public bool IsSingle()
        {
            return !string.IsNullOrWhiteSpace(this.Username);
        }
    }


    //[Route("/users", "PUT", Summary = "Create user.")] -- Users created with /register
    [Route("/users", "POST", Summary = "Update users name and email.")]
    public class UpdateUser : IReturnVoid
    {
        [ApiMember(Name = "FirstName", Description = "Users first name", IsRequired = true, ParameterType = "path")]
        public string FirstName { get; set; }

        [ApiMember(Name = "LastName", Description = "Users last name", IsRequired = true, ParameterType = "path")]
        public string LastName { get; set; }

        [ApiMember(Name = "Email", Description = "Users email address, will be used as username", IsRequired = true, ParameterType = "path")]
        public string Email { get; set; }

        public string Username { get; set; }
    }


    [Route("/users/{Username/changepassword", "POST", Summary = "Change users password.")]
    public class ChangeUsersPassword : IReturnVoid
    {
        [ApiMember(Name = "Username", Description = "Users username", IsRequired = true, ParameterType = "path")]
        public string Username { get; set; }

        [ApiMember(Name = "Password", Description = "Users current password", IsRequired = true, ParameterType = "path")]
        public string Password { get; set; }

        [ApiMember(Name = "NewPassword", Description = "Users requested password", IsRequired = true, ParameterType = "path")]
        public string NewPassword { get; set; }
    }
}
