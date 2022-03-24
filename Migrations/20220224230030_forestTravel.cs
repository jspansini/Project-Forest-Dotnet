using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaForest.Migrations
{
    public partial class forestTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastrarPassagem",
                columns: table => new
                {
                    IdPassagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoPassagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPassagem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastrarPassagem", x => x.IdPassagem);
                });

            migrationBuilder.CreateTable(
                name: "ComprarPassagem",
                columns: table => new
                {
                    IdPassagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoPassagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPassagem = table.Column<double>(type: "float", nullable: false),
                    cadastrarPassagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprarPassagem", x => x.IdPassagem);
                    table.ForeignKey(
                        name: "FK_ComprarPassagem_CadastrarPassagem_cadastrarPassagem",
                        column: x => x.cadastrarPassagem,
                        principalTable: "CadastrarPassagem",
                        principalColumn: "IdPassagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprarPassagem_cadastrarPassagem",
                table: "ComprarPassagem",
                column: "cadastrarPassagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprarPassagem");

            migrationBuilder.DropTable(
                name: "CadastrarPassagem");
        }
    }
}
