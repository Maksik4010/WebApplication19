using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class zaproszenia_do_grup
    {
        [Key]
        public int Id_zaproszenia_do_grup { get; set; }
        public String id_uzytkownicy { get; set; }
        public int id_grupy_dyskusyjne { get; set; }
        public grupy_dyskusyjne grupy_dyskusyjne { get; set; }
    }
}
