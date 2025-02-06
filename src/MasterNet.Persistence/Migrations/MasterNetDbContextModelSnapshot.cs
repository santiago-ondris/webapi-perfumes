﻿// <auto-generated />
using System;
using MasterNet.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4");

            modelBuilder.Entity("MasterNet.Domain.Calificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PerfumeId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Puntaje")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("calificaciones", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PerfumeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerfumeId");

                    b.ToTable("imagenes", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PerfumeId")
                        .HasColumnType("TEXT");

                    b.HasKey("IngredienteId", "PerfumeId");

                    b.HasIndex("PerfumeId");

                    b.ToTable("perfumes_ingredientes", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.PerfumePrecio", b =>
                {
                    b.Property<Guid>("PrecioId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PerfumeId")
                        .HasColumnType("TEXT");

                    b.HasKey("PrecioId", "PerfumeId");

                    b.HasIndex("PerfumeId");

                    b.ToTable("perfumes_precios", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Precio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("PrecioActual")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecioPromocion")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "48856202-6f8f-4797-893c-addb0c330ed1",
                            Name = "CLIENT",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_READ",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_UPDATE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_WRITE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_DELETE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_CREATE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_READ",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_UPDATE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_DELETE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "policies",
                            ClaimValue = "PERFUME_READ",
                            RoleId = "48856202-6f8f-4797-893c-addb0c330ed1"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "policies",
                            ClaimValue = "INGREDIENTE_READ",
                            RoleId = "48856202-6f8f-4797-893c-addb0c330ed1"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "48856202-6f8f-4797-893c-addb0c330ed1"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "policies",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "48856202-6f8f-4797-893c-addb0c330ed1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

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
