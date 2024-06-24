using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowersShopMVCTraining.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ShopCardCatalogChengeFildToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Catalog",
                table: "ShopCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Catalog",
                table: "ShopCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
