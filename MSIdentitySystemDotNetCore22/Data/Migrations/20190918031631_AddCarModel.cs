using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSIdentitySystemDotNetCore22.Data.Migrations
{
    public partial class AddCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    VIN = table.Column<int>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    DealershipID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
