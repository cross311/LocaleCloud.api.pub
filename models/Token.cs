using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class Token
    {
        public string Name { get; set; }

        public long AppId { get; set; }

        public long ReleaseId { get; set; }

        public long CreatedByUserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long DeactivatedReleaseId { get; set; }
    }
}
