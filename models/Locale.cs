using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace medidata.localeCloud.api.pub.dtos.models
{
    public class Locale
    {
        public string Id { get; set; }

        public string Language { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }

    public static class BaseLocales
    {
        public static Locale Eng =
            new Locale
            {
                Id = "en-us",
                Language = "English - United States",
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };


        public static Locale Jpn =
            new Locale
            {
                Id = "ja",
                Language = "Japanese",
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
    }
}
