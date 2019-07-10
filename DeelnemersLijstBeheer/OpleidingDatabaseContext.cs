using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    class OpleidingDatabaseContext : DbContext
    {
        public OpleidingDatabaseContext() : base("Opleiding") 
        {

        }
        public DbSet<Docenten> Docentenen { get; set; }
        public DbSet<Deelnemers> Deelnemers { get; set; }
        public DbSet<Tijdregistraties> TijdRegistraties { get; set; }
        public DbSet<OpleidingsInfo> OpleidingsInfos { get; set; }
        public DbSet<NietOpleidingsDagen> NietOpleidingsDagens { get; set; }
    }
}
