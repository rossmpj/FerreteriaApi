using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Ventas)
                .WithOne(v => v.Empleado)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Ventas)
                .WithOne(v => v.Producto)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Ventas)
                .WithOne(v => v.Cliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Marca>()
                .HasMany(m => m.Productos)
                .WithOne(p => p.Marca)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
