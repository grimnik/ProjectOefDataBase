using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    public class OpleidingDatabaseContext : DbContext
    {
        public OpleidingDatabaseContext() : base("Opleiding") 
        {

        }
        public DbSet<Docenten> Docentenen { get; set; }
        public DbSet<Deelnemers> Deelnemers { get; set; }
        public DbSet<Tijdregistraties> TijdRegistraties { get; set; }
        public DbSet<OpleidingsInfo> OpleidingsInfos { get; set; }
        public DbSet<NietOpleidingsDagen> NietOpleidingsDagens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OpleidingsInfo>()
                        .HasMany(s => s.Docentens)
                        .WithMany(c => c.OpleidingsInfo)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("DocentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("DocentCourse");
                        });
            modelBuilder.Entity<OpleidingsInfo>()
                        .HasMany<Deelnemers>(s => s.Deelnemers)
                        .WithMany(c => c.OpleidingsInfo)
                       
                        .Map(cs =>
                        {
                            cs.MapLeftKey("DeelnemersId");
                            cs.MapRightKey("OpleidingId");
                            cs.ToTable("DeelnemersOpleidingen");
                            
                        });

        }
        
    }
}
