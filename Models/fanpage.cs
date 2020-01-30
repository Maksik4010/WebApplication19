using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class fanpage
    {
        [Key]
        public int id_fanpage { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public string nazwa { get; set; }
        public string kategoria { get; set; }
        public int data_zalozenia { get; set; }
        public int liczba_polubien { get; set; }

        public ICollection<polubienia_fanpage> polubienia_Fanpages { get; set; }
    }
}
