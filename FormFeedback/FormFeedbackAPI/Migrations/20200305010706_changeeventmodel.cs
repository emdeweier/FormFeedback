using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormFeedbackAPI.Migrations
{
    public partial class changeeventmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_Events_TB_M_Room_RoomId",
                table: "TB_T_Events");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_Events_RoomId",
                table: "TB_T_Events");

            migrationBuilder.AlterColumn<string>(
                name: "PresentatorId",
                table: "TB_T_Events",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TB_M_Participant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "TB_M_Participant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TB_M_Participant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TB_M_Participant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TB_M_Participant");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TB_M_Participant");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TB_M_Participant");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TB_M_Participant");

            migrationBuilder.AlterColumn<int>(
                name: "PresentatorId",
                table: "TB_T_Events",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Events_RoomId",
                table: "TB_T_Events",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_Events_TB_M_Room_RoomId",
                table: "TB_T_Events",
                column: "RoomId",
                principalTable: "TB_M_Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
