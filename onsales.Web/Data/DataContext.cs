using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onsales.Common.Entities;
using onsales.Web.Data.Entities;

namespace onsales.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        //Constructor para la conexion a la base de datos
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Mapeamos las tablas
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        //Si creamos cada uno la tabla, tambien debemos crear en el metodo OnModelCreating los indices
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<Country>()
                .HasIndex(t => t.Name)
                .IsUnique();
            modelBuilder.Entity<City>()
              .HasIndex(t => t.Name)
              .IsUnique();
            modelBuilder.Entity<Department>()
              .HasIndex(t => t.Name)
              .IsUnique();
            modelBuilder.Entity<Category>()
            .HasIndex(t => t.Name)
            .IsUnique();
            modelBuilder.Entity<Product>()
           .HasIndex(t => t.Name)
           .IsUnique();
        }

    }


}
