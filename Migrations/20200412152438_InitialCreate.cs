using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLiteTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    IP = table.Column<string>(nullable: false),
                    Netmask = table.Column<string>(nullable: false),
                    Gateway = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false, defaultValue: false),
                    Type = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.IP);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");
        }
    }
}
