using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class czlonkowie_grup
    {
        [Key]
        public int id_czlonkowie_grup { get; set; }
        public int id_grupy_dyskusyjne { get; set; }
        public grupy_dyskusyjne grupy_Dyskusyjne { get; set; }
        public String id_uzytkownicy { get; set; }
        public int data_dolaczenia { get; set; }
    }
}
