using Finanzas.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Models
{
    public interface IContextoFinanzas
    {
       DbSet<Cuenta> Cuentas { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Tipo> Tipos { get; set; }
        DbSet<Transaccion> Transaccions { get; set; }
        DbSet<Moneda> Monedas { get; set; }
        int SaveChanges();

    }
    public class ContextoFinanzas : DbContext, IContextoFinanzas
    {
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public ContextoFinanzas()
        {

        }
        public ContextoFinanzas(DbContextOptions<ContextoFinanzas> o) : base(o) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new TipoMap());
            modelBuilder.ApplyConfiguration(new TransaccionMap());
            modelBuilder.ApplyConfiguration(new MonedaMap());
        }
    }
}
