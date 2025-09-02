using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class firtMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    _idLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _añoDePublicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x._idLibro);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    _idUsario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _numeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x._idUsario);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    _idPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _idLibro = table.Column<int>(type: "int", nullable: false),
                    _idUsuario = table.Column<int>(type: "int", nullable: false),
                    _fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x._idPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros__idLibro",
                        column: x => x._idLibro,
                        principalTable: "Libros",
                        principalColumn: "_idLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios__idUsuario",
                        column: x => x._idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "_idUsario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos__idLibro",
                table: "Prestamos",
                column: "_idLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos__idUsuario",
                table: "Prestamos",
                column: "_idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
