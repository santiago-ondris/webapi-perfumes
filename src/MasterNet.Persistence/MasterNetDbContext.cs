using MasterNet.Domain;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Persistence
{
    public class MasterNetDbContext : IdentityDbContext<AppUsuario>
{
        public MasterNetDbContext(DbContextOptions<MasterNetDbContext> options) : base(options)
        {

        }

        public DbSet<Perfume>? Perfumes { get; set; }
        public DbSet<Ingrediente>? Ingredientes { get; set; }
        public DbSet<Precio>? Precios { get; set; }
        public DbSet<Calificacion>? Calificaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Declaración de entidades como tablas
            modelBuilder.Entity<Perfume>().ToTable("perfumes");
            modelBuilder.Entity<Ingrediente>().ToTable("ingredientes");
            modelBuilder.Entity<PerfumeIngrediente>().ToTable("perfumes_ingredientes");
            modelBuilder.Entity<Precio>().ToTable("precios");
            modelBuilder.Entity<PerfumePrecio>().ToTable("perfumes_precios");
            modelBuilder.Entity<Calificacion>().ToTable("calificaciones");
            modelBuilder.Entity<Foto>().ToTable("imagenes");

            // Ejemplo: Configurar decimales
            modelBuilder.Entity<Precio>()
                .Property(b => b.PrecioActual)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Precio>()
                .Property(b => b.PrecioPromocion)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Precio>()
                .Property(b => b.Nombre)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250);

            // Relaciones
            modelBuilder.Entity<Perfume>()
                .HasMany(m => m.Fotos)
                .WithOne(m => m.Perfume)
                .HasForeignKey(m => m.PerfumeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Perfume>()
                .HasMany(m => m.Calificaciones)
                .WithOne(m => m.Perfume)
                .HasForeignKey(m => m.PerfumeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Muchos a muchos: Perfume <-> Precio
            modelBuilder.Entity<Perfume>()
                .HasMany(m => m.Precios)
                .WithMany(m => m.Perfumes)
                .UsingEntity<PerfumePrecio>(
                    j => j
                        .HasOne(p => p.Precio)
                        .WithMany(p => p.PerfumePrecios)
                        .HasForeignKey(p => p.PrecioId),
                    j => j
                        .HasOne(p => p.Perfume)
                        .WithMany(p => p.PerfumePrecios)
                        .HasForeignKey(p => p.PerfumeId),
                    j => { j.HasKey(t => new { t.PrecioId, t.PerfumeId }); }
                );

            // Muchos a muchos: Perfume <-> Ingrediente
            modelBuilder.Entity<Perfume>()
                .HasMany(m => m.Ingredientes)
                .WithMany(m => m.Perfumes)
                .UsingEntity<PerfumeIngrediente>(
                    j => j
                        .HasOne(p => p.Ingrediente)
                        .WithMany(p => p.PerfumeIngredientes)
                        .HasForeignKey(p => p.IngredienteId),
                    j => j
                        .HasOne(p => p.Perfume)
                        .WithMany(p => p.PerfumeIngredientes)
                        .HasForeignKey(p => p.PerfumeId),
                    j => { j.HasKey(t => new { t.IngredienteId, t.PerfumeId }); }
                );

            // === SEED ESTÁTICO con HasData === //

            // 1) Perfumes
            modelBuilder.Entity<Perfume>().HasData(
                new Perfume
                {
                    Id = DataSeed.Perfume1Id,
                    Nombre = "Y Eau de Parfum",
                    Descripcion = "Un perfume elegante para ocasiones especiales.",
                    FechaPublicacion = new DateTime(2022, 1, 1),
                },
                new Perfume
                {
                    Id = DataSeed.Perfume2Id,
                    Nombre = "Man in Black Parfum",
                    Descripcion = "Aroma fresco para uso diario",
                    FechaPublicacion = new DateTime(2022, 2, 1),
                },
                new Perfume
                {
                    Id = DataSeed.Perfume3Id,
                    Nombre = "Lhomme ideal Parfum",
                    Descripcion = "Aroma dulce y sutil",
                    FechaPublicacion = new DateTime(2022, 3, 1),
                },
                new Perfume
                {
                    Id = DataSeed.Perfume4Id,
                    Nombre = "Myslf Le Parfum",
                    Descripcion = "Notas amaderadas intensas",
                    FechaPublicacion = new DateTime(2022, 4, 1),
                },
                new Perfume
                {
                    Id = DataSeed.Perfume5Id,
                    Nombre = "Tygar",
                    Descripcion = "Aroma tropical y exótico",
                    FechaPublicacion = new DateTime(2022, 5, 1),
                }
            );

            // 2) Precio
            modelBuilder.Entity<Precio>().HasData(
                new Precio
                {
                    Id = DataSeed.PrecioRegularId,
                    PrecioActual = 100.0m,
                    PrecioPromocion = 80.0m,
                    Nombre = "Precio Regular"
                }
            );

            // 3) Ingredientes
            modelBuilder.Entity<Ingrediente>().HasData(
                new Ingrediente
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Nombre = "Rosa"
                },
                new Ingrediente
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Nombre = "Jazmín"
                }
            );

            CargarDataSeguridad(modelBuilder);
        }
        private void CargarDataSeguridad(ModelBuilder modelBuilder)
        {
            var adminId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Id = adminId,
                    Name = CustomRoles.ADMIN,
                    NormalizedName = CustomRoles.ADMIN
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Id = clientId,
                    Name = CustomRoles.CLIENT,
                    NormalizedName = CustomRoles.CLIENT
                }
            );    

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
                new IdentityRoleClaim<string> {
                    Id = 1,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.PERFUME_READ,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 2,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.PERFUME_UPDATE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 3,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.PERFUME_WRITE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 4,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.PERFUME_DELETE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 5,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.INGREDIENTE_CREATE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 6,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.INGREDIENTE_READ,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 7,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.INGREDIENTE_UPDATE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 8,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.COMENTARIO_READ,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 9,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.COMENTARIO_DELETE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 10,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.COMENTARIO_CREATE,
                    RoleId = adminId
                },
                new IdentityRoleClaim<string> {
                    Id = 11,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.PERFUME_READ,
                    RoleId = clientId
                },
                new IdentityRoleClaim<string> {
                    Id = 12,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.INGREDIENTE_READ,
                    RoleId = clientId
                },
                new IdentityRoleClaim<string> {
                    Id = 13,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.COMENTARIO_READ,
                    RoleId = clientId
                },
                new IdentityRoleClaim<string> {
                    Id = 14,
                    ClaimType = CustomClaims.policies,
                    ClaimValue = PolicyMaster.COMENTARIO_CREATE,
                    RoleId = clientId
                }
            );        
        }
    }
}