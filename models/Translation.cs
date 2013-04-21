using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class Translation
    {
        public string Text { get; set; }

        public long TokenId { get; set; }

        public string LocaleId { get; set; }

        public long CreatedByUserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
