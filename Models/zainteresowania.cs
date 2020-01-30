using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class zainteresowania
    {
        [Key]
        public int Id_zainteresowania { get; set; }
        public string nazwa { get; set; }
        public string kategoria { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public int liczba_zainteresowanych { get; set; }
    }
}
