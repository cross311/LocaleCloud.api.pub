using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class User
    {
        public string UserAuthId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string GravatarImageUrl64 { get; set; }

        public List<string> LocaleIds { get; set; }

        public bool IsAppUser { get; set; }

        public long AppId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
