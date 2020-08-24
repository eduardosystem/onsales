using Microsoft.EntityFrameworkCore;
using onsales.Common.Entities;

namespace onsales.Web.Data
{
    public class DataContext : DbContext
    {
        //Constructor para la conexion a la base de datos
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Mapeamos las tablas
        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }

    }


}
