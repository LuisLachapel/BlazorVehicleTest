using Microsoft.EntityFrameworkCore;

namespace BlazorVehicleTest.Data
{
    public class ConexionDBContext: DbContext
    {
        public ConexionDBContext (DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<tb_vehiculo>().HasKey(v => v.Vehiculo_id);
            builder.Entity<tb_marca>().HasKey(v => v.Marca_id);
            builder.Entity<tb_modelo>().HasKey(m => m.Modelo_id);

        }

        public DbSet<tb_vehiculo> tb_vehiculo { get; set; }
        public DbSet<tb_marca> tb_marca { get; set; }
        public DbSet<tb_modelo> tb_modelo { get; set; }
    }
}
