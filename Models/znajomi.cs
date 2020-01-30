using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class znajomi
    {
        [Key]
        public int Id_znajomi { get; set; }
        public String Id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy {get; set;}
        public String Id_znajomwgo { get; set; }
        public long poczatek_znajomosci { get; set; }

        public DateTime getDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
