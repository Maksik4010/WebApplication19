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
        public int data_utworzenia { get; set; }
        public int czy_usunieta { get; set; }

    }
}
