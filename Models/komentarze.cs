using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class komentarze
    {
        [Key]
        public int id_komentarze { get; set; }
        public int id_posty { get; set; }
        public posty posty { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public string tresc { get; set; }
        public long data_utworzenia { get; set; }
        public int liczba_like { get; set; }
        public int liczba_dislike { get; set; }

        public DateTime getDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
