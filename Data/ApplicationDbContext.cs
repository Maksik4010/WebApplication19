using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication19.Models;

namespace WebApplication19.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //properties
        public DbSet<uzytkownicy> uzytkownicies { get; set; }
        public DbSet<czlonkowie_grup> czlonkowie_Grups { get; set; }
        public DbSet<fanpage> fanpages { get; set; }
        public DbSet<filmy> filmies { get; set; }
        public DbSet<grupy_dyskusyjne> grupy_Dyskusyjnes { get; set; }
        public DbSet<komentarze> komentarzes { get; set; }
        public DbSet<pliki> plikis { get; set; }
        public DbSet<polubienia_fanpage> polubienia_Fanpages { get; set; }
        public DbSet<komentarze> komentarzess { get; set; }
        public DbSet<posty> posties { get; set; }
        public DbSet<reakcja_na_posty> reakcja_Na_Posties { get; set; }
        public DbSet<wiadomosci> wiadomoscis { get; set; }
        public DbSet<zainteresowania> zainteresowanias { get; set; }
        public DbSet<zaproszenia_do_grup> zaproszenia_Do_Grups { get; set; }
        public DbSet<zaproszenia_do_znajomych> zaproszenia_Do_Znajomyches { get; set; }
        public DbSet<zdjecia> zdjecias { get; set; }
        public DbSet<znajomi> znajomis { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
