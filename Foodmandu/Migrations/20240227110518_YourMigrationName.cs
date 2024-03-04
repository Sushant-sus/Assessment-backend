using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodmandu.Migrations
{
    public partial class YourMigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LayoutItems",
                columns: table => new
                {
                    LayoutItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    layoutId = table.Column<int>(type: "int", nullable: false),
                    displayOrder = table.Column<int>(type: "int", nullable: false),
                    featured = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extraInfo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extraInfo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentLayoutItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutItems", x => x.LayoutItemId);
                });

            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    layoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    layout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displayOrder = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tagline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderLinkJSON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeeMoreJSON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seeMore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ratio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    webdisplayorder = table.Column<int>(type: "int", nullable: false),
                    allowwebdisplay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.layoutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutItems");

            migrationBuilder.DropTable(
                name: "Layouts");
        }
    }
}
