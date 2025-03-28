﻿// <auto-generated />
using System;
using MasterNet.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MasterNet.Persistence.Migrations
{
    [DbContext(typeof(MasterNetDbContext))]
    partial class MasterNetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MasterNet.Domain.Calificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PerfumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("calificaciones", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PerfumeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("imagenes", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ingredientes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            Nombre = "Rosa"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            Nombre = "Jazmín"
                        });
                });

            modelBuilder.Entity("MasterNet.Domain.Perfume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("perfumes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                            Descripcion = "Un perfume elegante para ocasiones especiales.",
                            FechaPublicacion = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Y Eau de Parfum"
                        },
                        new
                        {
                            Id = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                            Descripcion = "Aroma fresco para uso diario",
                            FechaPublicacion = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Man in Black Parfum"
                        },
                        new
                        {
                            Id = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                            Descripcion = "Aroma dulce y sutil",
                            FechaPublicacion = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Lhomme ideal Parfum"
                        },
                        new
                        {
                            Id = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                            Descripcion = "Notas amaderadas intensas",
                            FechaPublicacion = new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Myslf Le Parfum"
                        },
                        new
                        {
                            Id = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                            Descripcion = "Aroma tropical y exótico",
                            FechaPublicacion = new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Tygar"
                        });
                });

            modelBuilder.Entity("MasterNet.Domain.PerfumeIngrediente", b =>
                {
                    b.Property<Guid>("IngredienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PerfumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngredienteId", "PerfumeId");

                    b.HasIndex("PerfumeId");

                    b.ToTable("perfumes_ingredientes", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.PerfumePrecio", b =>
                {
                    b.Property<Guid>("PrecioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PerfumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PrecioId", "PerfumeId");

                    b.HasIndex("PerfumeId");

                    b.ToTable("perfumes_precios", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Precio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("PrecioActual")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PrecioPromocion")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("precios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            Nombre = "Precio Regular",
                            PrecioActual = 100.0m,
                            PrecioPromocion = 80.0m
                        });
                });

            modelBuilder.Entity("MasterNet.Persistence.Models.AppUsuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d3b3f882-24b5-4e92-9a34-123456789012",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "c8b1fabc-567d-4c45-8c12-098765432109",
                            Name = "CLIENT",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_READ",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_UPDATE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_WRITE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_DELETE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_CREATE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_READ",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_UPDATE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_DELETE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "d3b3f882-24b5-4e92-9a34-123456789012"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_READ",
                            RoleId = "c8b1fabc-567d-4c45-8c12-098765432109"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_READ",
                            RoleId = "c8b1fabc-567d-4c45-8c12-098765432109"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "c8b1fabc-567d-4c45-8c12-098765432109"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "c8b1fabc-567d-4c45-8c12-098765432109"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Calificacion", b =>
                {
                    b.HasOne("MasterNet.Domain.Perfume", "Perfume")
                        .WithMany("Calificaciones")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("MasterNet.Domain.Foto", b =>
                {
                    b.HasOne("MasterNet.Domain.Perfume", "Perfume")
                        .WithMany("Fotos")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("MasterNet.Domain.PerfumeIngrediente", b =>
                {
                    b.HasOne("MasterNet.Domain.Ingrediente", "Ingrediente")
                        .WithMany("PerfumeIngredientes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterNet.Domain.Perfume", "Perfume")
                        .WithMany("PerfumeIngredientes")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("MasterNet.Domain.PerfumePrecio", b =>
                {
                    b.HasOne("MasterNet.Domain.Perfume", "Perfume")
                        .WithMany("PerfumePrecios")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterNet.Domain.Precio", "Precio")
                        .WithMany("PerfumePrecios")
                        .HasForeignKey("PrecioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfume");

                    b.Navigation("Precio");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MasterNet.Persistence.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MasterNet.Persistence.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterNet.Persistence.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MasterNet.Persistence.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterNet.Domain.Ingrediente", b =>
                {
                    b.Navigation("PerfumeIngredientes");
                });

            modelBuilder.Entity("MasterNet.Domain.Perfume", b =>
                {
                    b.Navigation("Calificaciones");

                    b.Navigation("Fotos");

                    b.Navigation("PerfumeIngredientes");

                    b.Navigation("PerfumePrecios");
                });

            modelBuilder.Entity("MasterNet.Domain.Precio", b =>
                {
                    b.Navigation("PerfumePrecios");
                });
#pragma warning restore 612, 618
        }
    }
}
