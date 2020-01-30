using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class polubienia_fanpage
    {
        [Key]
        public int id_polubienia_fanpage { get; set; }
        public String id_fanpage { get; set; }
        public fanpage fanpage { get; set; }
        public int id_uzytkownicy { get; set; }

    }
}
