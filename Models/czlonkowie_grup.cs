using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class czlonkowie_grup
    {
        [Key]
        public int id_czlonkowie_grup { get; set; }
        public int id_grupy_dyskusyjne { get; set; }
        public grupy_dyskusyjne grupy_Dyskusyjne { get; set; }
        public String id_uzytkownicy { get; set; }
        public long data_dolaczenia { get; set; }

        public DateTime getDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
