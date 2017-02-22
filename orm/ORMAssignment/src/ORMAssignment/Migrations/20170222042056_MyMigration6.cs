using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORMAssignment.Migrations
{
    public partial class MyMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_update_product_ProductId",
                table: "update");

            migrationBuilder.DropPrimaryKey(
                name: "PK_update",
                table: "update");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "update",
                newName: "UpdateTable");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "ProductTable");

            migrationBuilder.RenameIndex(
                name: "IX_update_ProductId",
                table: "UpdateTable",
                newName: "IX_UpdateTable_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductTable",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpdateTable",
                table: "UpdateTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTable",
                table: "ProductTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateTable_ProductTable_ProductId",
                table: "UpdateTable",
                column: "ProductId",
                principalTable: "ProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpdateTable_ProductTable_ProductId",
                table: "UpdateTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpdateTable",
                table: "UpdateTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTable",
                table: "ProductTable");

            migrationBuilder.RenameTable(
                name: "UpdateTable",
                newName: "update");

            migrationBuilder.RenameTable(
                name: "ProductTable",
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_UpdateTable_ProductId",
                table: "update",
                newName: "IX_update_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "product",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_update",
                table: "update",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_update_product_ProductId",
                table: "update",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
