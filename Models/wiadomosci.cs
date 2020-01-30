using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class wiadomosci
    {
        [Key]
        public int Id_wiadomosci { get; set; }
        public int Id_konwersacji { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public string tresc { get; set; }
        public long data_utworzenia { get; set; }
        public int czy_usunieta { get; set; }

        public DateTime getDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }
}
