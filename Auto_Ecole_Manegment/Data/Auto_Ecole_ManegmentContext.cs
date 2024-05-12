using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Auto_ecole_project.Models;

namespace Auto_Ecole_Manegment.Data
{
    public class Auto_Ecole_ManegmentContext : DbContext
    {
        public Auto_Ecole_ManegmentContext (DbContextOptions<Auto_Ecole_ManegmentContext> options)
            : base(options)
        {
        }

        public DbSet<Auto_ecole_project.Models.Condidat> Condidat { get; set; } = default!;
        public DbSet<Auto_ecole_project.Models.Moniteur> Moniteur { get; set; } = default!;
        public DbSet<Auto_ecole_project.Models.Cours> Cours { get; set; } = default!;
        public DbSet<Auto_ecole_project.Models.Session> Session { get; set; } = default!;
        public DbSet<Auto_ecole_project.Models.Examen> Examen { get; set; } = default!;
        public DbSet<Auto_ecole_project.Models.Voiture> Voiture { get; set; } = default!;
    }
}
