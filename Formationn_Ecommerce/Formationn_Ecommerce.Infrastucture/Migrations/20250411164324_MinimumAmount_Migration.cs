using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formationn_Ecommerce.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class MinimumAmount_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAmount",
                table: "Coupons",
                newName: "MinimumAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinimumAmount",
                table: "Coupons",
                newName: "MinAmount");
        }
    }
}
