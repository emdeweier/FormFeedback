using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class changefeedbackmodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_T_Events_EventId",
                table: "TB_T_Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Participant_ParticipantId",
                table: "TB_T_Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_EventId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_ParticipantId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_PointId",
                table: "TB_T_Feedback");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Feedback_QuestionId",
                table: "TB_T_Feedback");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_EventId",
                table: "TB_T_Feedback",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_ParticipantId",
                table: "TB_T_Feedback",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_PointId",
                table: "TB_T_Feedback",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Feedback_QuestionId",
                table: "TB_T_Feedback",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_T_Events_EventId",
                table: "TB_T_Feedback",
                column: "EventId",
                principalTable: "TB_T_Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Participant_ParticipantId",
                table: "TB_T_Feedback",
                column: "ParticipantId",
                principalTable: "TB_M_Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Points_PointId",
                table: "TB_T_Feedback",
                column: "PointId",
                principalTable: "TB_M_Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Feedback_TB_M_Questions_QuestionId",
                table: "TB_T_Feedback",
                column: "QuestionId",
                principalTable: "TB_M_Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
