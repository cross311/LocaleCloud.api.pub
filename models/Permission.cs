using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class Permission
    {
        public long AppId { get; set; }

        public long UserId { get; set; }

        public PermissionType PermissionType { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
