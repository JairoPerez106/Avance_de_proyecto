using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendarcitas.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendar_citas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendar_citas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cedula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    direccion = table.Column<string>(type: "TEXT", nullable: false),
                    telefono = table.Column<int>(type: "INTEGER", nullable: false),
                    Citaid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.cedula);
                    table.ForeignKey(
                        name: "FK_Clientes_Agendar_citas_Citaid",
                        column: x => x.Citaid,
                        principalTable: "Agendar_citas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Citaid",
                table: "Clientes",
                column: "Citaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Agendar_citas");
        }
    }
}
