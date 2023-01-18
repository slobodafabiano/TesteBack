using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBack.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_idFornecedor1",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "idFornecedor1",
                table: "Endereco",
                newName: "FornecedoridFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_idFornecedor1",
                table: "Endereco",
                newName: "IX_Endereco_FornecedoridFornecedor");

            migrationBuilder.AddColumn<int>(
                name: "Fornecedor_id",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedoridFornecedor",
                table: "Endereco",
                column: "FornecedoridFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "idFornecedor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedoridFornecedor",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Fornecedor_id",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "FornecedoridFornecedor",
                table: "Endereco",
                newName: "idFornecedor1");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_FornecedoridFornecedor",
                table: "Endereco",
                newName: "IX_Endereco_idFornecedor1");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_idFornecedor1",
                table: "Endereco",
                column: "idFornecedor1",
                principalTable: "Fornecedor",
                principalColumn: "idFornecedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
