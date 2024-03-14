using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_VariantProperties_variantPropertyPropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantProperties_ProductVariants_productVariantVariantId",
                table: "VariantProperties");

            migrationBuilder.AlterColumn<int>(
                name: "productVariantVariantId",
                table: "VariantProperties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "variantPropertyPropertyId",
                table: "PropertyDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_VariantProperties_variantPropertyPropertyId",
                table: "PropertyDetails",
                column: "variantPropertyPropertyId",
                principalTable: "VariantProperties",
                principalColumn: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantProperties_ProductVariants_productVariantVariantId",
                table: "VariantProperties",
                column: "productVariantVariantId",
                principalTable: "ProductVariants",
                principalColumn: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_VariantProperties_variantPropertyPropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantProperties_ProductVariants_productVariantVariantId",
                table: "VariantProperties");

            migrationBuilder.AlterColumn<int>(
                name: "productVariantVariantId",
                table: "VariantProperties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "variantPropertyPropertyId",
                table: "PropertyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_VariantProperties_variantPropertyPropertyId",
                table: "PropertyDetails",
                column: "variantPropertyPropertyId",
                principalTable: "VariantProperties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantProperties_ProductVariants_productVariantVariantId",
                table: "VariantProperties",
                column: "productVariantVariantId",
                principalTable: "ProductVariants",
                principalColumn: "VariantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
