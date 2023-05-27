using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pAspFinal.Migrations
{
    public partial class MigrationChoixChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choix_Questions_QuestionId",
                table: "Choix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choix",
                table: "Choix");

            migrationBuilder.RenameTable(
                name: "Choix",
                newName: "Choixs");

            migrationBuilder.RenameIndex(
                name: "IX_Choix_QuestionId",
                table: "Choixs",
                newName: "IX_Choixs_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choixs",
                table: "Choixs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Choixs_Questions_QuestionId",
                table: "Choixs",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choixs_Questions_QuestionId",
                table: "Choixs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choixs",
                table: "Choixs");

            migrationBuilder.RenameTable(
                name: "Choixs",
                newName: "Choix");

            migrationBuilder.RenameIndex(
                name: "IX_Choixs_QuestionId",
                table: "Choix",
                newName: "IX_Choix_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choix",
                table: "Choix",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Choix_Questions_QuestionId",
                table: "Choix",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
