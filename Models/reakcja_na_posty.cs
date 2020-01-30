using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class reakcja_na_posty
    {
        [Key]
        public int id_reakcje_na_posty { get; set; }
        public int id_wydarzenia { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public int typ { get; set; }
    }
}
