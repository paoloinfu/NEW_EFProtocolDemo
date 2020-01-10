using Microsoft.EntityFrameworkCore.Migrations;

namespace EFProtocolDemo.Migrations
{
    public partial class pippo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    ProtId = table.Column<string>(nullable: false),
                    DataInvio = table.Column<string>(nullable: true),
                    DataRicezione = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Mittente = table.Column<string>(nullable: true),
                    Destinatario = table.Column<string>(nullable: true),
                    Oggetto = table.Column<string>(nullable: true),
                    Allegati = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.ProtId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mails");
        }
    }
}
