using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class App
    {
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string BaseLocaleId { get; set; }

        public List<string> LocaleIds { get; set; }

        public bool AllowAutoCreate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
