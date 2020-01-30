using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class filmy
    {
        [Key]
        public int id_filmy { get; set; }
        public string nazwa { get; set; }
        public String id_uzytkownicy { get; set; }
        public uzytkownicy uzytkownicy { get; set; }
        public string link_bezposredni { get; set; }
    }
}
