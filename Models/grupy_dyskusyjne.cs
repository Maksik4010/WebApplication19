using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class grupy_dyskusyjne
    {
        [Key]
        public int id_grupy_dyskusyjne { get; set; }
        [Required]
        [Display(Name = "Nazwa grupy: ")]
        public string nazwa { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public long data_zalozenia { get; set; }

        public ICollection<zaproszenia_do_grup> zaproszenia_Do_Grups { get; set; }
        public ICollection<czlonkowie_grup> czlonkowie_Grups { get; set; }

        public DateTime getDate(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
