using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class changeparticipantmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Participant_TB_T_Events_EventId",
                table: "TB_M_Participant");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Participant_EventId",
                table: "TB_M_Participant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Participant_EventId",
                table: "TB_M_Participant",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Participant_TB_T_Events_EventId",
                table: "TB_M_Participant",
                column: "EventId",
                principalTable: "TB_T_Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
