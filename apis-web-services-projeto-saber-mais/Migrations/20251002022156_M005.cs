using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apis_web_services_projeto_saber_mais.Migrations
{
    /// <inheritdoc />
    public partial class M005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorArea_Areas_AreasId",
                table: "ProfessorArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorArea_Professores_ProfessoresId",
                table: "ProfessorArea");

            migrationBuilder.RenameColumn(
                name: "ProfessoresId",
                table: "ProfessorArea",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "AreasId",
                table: "ProfessorArea",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorArea_ProfessoresId",
                table: "ProfessorArea",
                newName: "IX_ProfessorArea_AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorArea_Areas_AreaId",
                table: "ProfessorArea",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorArea_Professores_ProfessorId",
                table: "ProfessorArea",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorArea_Areas_AreaId",
                table: "ProfessorArea");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorArea_Professores_ProfessorId",
                table: "ProfessorArea");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "ProfessorArea",
                newName: "ProfessoresId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "ProfessorArea",
                newName: "AreasId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorArea_AreaId",
                table: "ProfessorArea",
                newName: "IX_ProfessorArea_ProfessoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorArea_Areas_AreasId",
                table: "ProfessorArea",
                column: "AreasId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorArea_Professores_ProfessoresId",
                table: "ProfessorArea",
                column: "ProfessoresId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
