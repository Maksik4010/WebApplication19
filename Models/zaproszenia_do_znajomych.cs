using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class zaproszenia_do_znajomych
    {
        [Key]
        public int Id_zapraszającego { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public int data_zaproszenia { get; set; }
    }
}
