using Microsoft.EntityFrameworkCore.Migrations;

namespace Mehno_Gavril_Volunteers.Migrations
{
    public partial class VolunteerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Volunteer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VolunteerCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerCategory_Volunteer_VolunteerID",
                        column: x => x.VolunteerID,
                        principalTable: "Volunteer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_PublisherID",
                table: "Volunteer",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerCategory_CategoryID",
                table: "VolunteerCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerCategory_VolunteerID",
                table: "VolunteerCategory",
                column: "VolunteerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_Publisher_PublisherID",
                table: "Volunteer",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_Publisher_PublisherID",
                table: "Volunteer");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "VolunteerCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer_PublisherID",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Volunteer");
        }
    }
}
