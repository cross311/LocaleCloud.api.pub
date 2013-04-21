using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class TranslationTask
    {
        public long TokenId { get; set; }

        public long? UserId { get; set; }

        public string LocaleId { get; set; }

        public long AppId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
