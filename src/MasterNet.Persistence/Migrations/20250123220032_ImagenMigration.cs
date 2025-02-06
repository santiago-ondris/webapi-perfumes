using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImagenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Nacionalidad = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perfumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    PrecioActual = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    Puntaje = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    PerfumeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calificaciones_perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    PerfumeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfumes_ingredientes",
                columns: table => new
                {
                    PerfumeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfumes_ingredientes", x => new { x.IngredienteId, x.PerfumeId });
                    table.ForeignKey(
                        name: "FK_perfumes_ingredientes_ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfumes_ingredientes_perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfumes_precios",
                columns: table => new
                {
                    PerfumeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrecioId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfumes_precios", x => new { x.PrecioId, x.PerfumeId });
                    table.ForeignKey(
                        name: "FK_perfumes_precios_perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfumes_precios_precios_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48856202-6f8f-4797-893c-addb0c330ed1", null, "CLIENT", "CLIENT" },
                    { "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "ingredientes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Rosa" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Jazmín" }
                });

            migrationBuilder.InsertData(
                table: "perfumes",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Nombre" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Un perfume elegante para ocasiones especiales.", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Y Eau de Parfum" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Aroma fresco para uso diario", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Man in Black Parfum" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Aroma dulce y sutil", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lhomme ideal Parfum" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Notas amaderadas intensas", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myslf Le Parfum" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Aroma tropical y exótico", new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tygar" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), "Precio Regular", 100.0m, 80.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "policies", "PERFUME_READ", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 2, "policies", "PERFUME_UPDATE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 3, "policies", "PERFUME_WRITE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 4, "policies", "PERFUME_DELETE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 5, "policies", "INGREDIENTE_CREATE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 6, "policies", "INGREDIENTE_READ", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 7, "policies", "INGREDIENTE_UPDATE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 8, "policies", "COMENTARIO_READ", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 9, "policies", "COMENTARIO_DELETE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 10, "policies", "COMENTARIO_CREATE", "9c0bb1f5-e687-4de2-abb2-112f11e0ecc8" },
                    { 11, "policies", "PERFUME_READ", "48856202-6f8f-4797-893c-addb0c330ed1" },
                    { 12, "policies", "INGREDIENTE_READ", "48856202-6f8f-4797-893c-addb0c330ed1" },
                    { 13, "policies", "COMENTARIO_READ", "48856202-6f8f-4797-893c-addb0c330ed1" },
                    { 14, "policies", "COMENTARIO_CREATE", "48856202-6f8f-4797-893c-addb0c330ed1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_PerfumeId",
                table: "calificaciones",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_PerfumeId",
                table: "imagenes",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_perfumes_ingredientes_PerfumeId",
                table: "perfumes_ingredientes",
                column: "PerfumeId");

            migrationBuilder.CreateIndex(
                name: "IX_perfumes_precios_PerfumeId",
                table: "perfumes_precios",
                column: "PerfumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "perfumes_ingredientes");

            migrationBuilder.DropTable(
                name: "perfumes_precios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ingredientes");

            migrationBuilder.DropTable(
                name: "perfumes");

            migrationBuilder.DropTable(
                name: "precios");
        }
    }
}
