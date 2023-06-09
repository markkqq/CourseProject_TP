using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Tournament_TournamentId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Club_ClubId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Player_ClubId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_TournamentId",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Player",
                newName: "Фамилия");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Player",
                newName: "Имя");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Club",
                newName: "Название");

            migrationBuilder.AddColumn<int>(
                name: "ClubEntityId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentEntityId",
                table: "GameSession",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubEntityId",
                table: "Player",
                column: "ClubEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_TournamentEntityId",
                table: "GameSession",
                column: "TournamentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Tournament_TournamentEntityId",
                table: "GameSession",
                column: "TournamentEntityId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Club_ClubEntityId",
                table: "Player",
                column: "ClubEntityId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSession_Tournament_TournamentEntityId",
                table: "GameSession");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Club_ClubEntityId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_ClubEntityId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_GameSession_TournamentEntityId",
                table: "GameSession");

            migrationBuilder.DropColumn(
                name: "ClubEntityId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TournamentEntityId",
                table: "GameSession");

            migrationBuilder.RenameColumn(
                name: "Фамилия",
                table: "Player",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Имя",
                table: "Player",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Название",
                table: "Club",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "GameSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    GameSessionEntityId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_GameSession_GameSessionEntityId",
                        column: x => x.GameSessionEntityId,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubId",
                table: "Player",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_TournamentId",
                table: "GameSession",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ClubId",
                table: "Participant",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_GameSessionEntityId",
                table: "Participant",
                column: "GameSessionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TournamentId",
                table: "Participant",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSession_Tournament_TournamentId",
                table: "GameSession",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Club_ClubId",
                table: "Player",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
