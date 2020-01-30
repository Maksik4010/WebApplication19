using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication19.Models
{
    public class uzytkownicy
    {
        [Key]
        public String id{ get; set; }

       
        [Display(Name = "Login")]
        public string login { get; set; }

        
        [Display(Name = "Hasło")]
        [StringLength(32, ErrorMessage = "{0} musi mieć od {2} do {1} znaków.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string haslo { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string imie { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }

        [Required]
        [Display(Name = "Ksywka")]
        public string ksywka { get; set; }

        [Required]
        [Display(Name = "Kraj")]
        public string kraj { get; set; }

        public long data_zalozenia { get; set; }
        public int ostatnie_logowanie { get; set; }
        public int ip_ostatniego_logowania { get; set; }
        public int liczba_znajomych { get; set; }

        public ICollection<znajomi> Znajomis { get; set; }
        public ICollection<zdjecia> Zdjecias { get; set; }
        public ICollection<zaproszenia_do_znajomych> zaproszenia_Do_Znajomyches { get; set; }
        public ICollection<zainteresowania> zainteresowanias { get; set; }
        public ICollection<wiadomosci> wiadomoscis { get; set; }
        public ICollection<posty> posties { get; set; }
        public ICollection<pliki> plikis { get; set; }
        public ICollection<komentarze> komentarzes { get; set; }
        public ICollection<grupy_dyskusyjne> grupy_Dyskusyjnes { get; set; }
        public ICollection<filmy> filmies { get; set; }
        public ICollection<fanpage> fanpages { get; set; }
        public ICollection<reakcja_na_posty> reakcja_Na_Posties { get; set; }

        public string getName()
        {
            return this.imie;
        }

        public string getSurname()
        {
            return this.nazwisko;
        }
    }


}
