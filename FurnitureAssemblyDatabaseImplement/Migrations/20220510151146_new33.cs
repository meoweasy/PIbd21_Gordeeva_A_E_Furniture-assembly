using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureAssemblyDatabaseImplement.Migrations
{
    public partial class new33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesInfo_Clients_ClientId",
                table: "MessagesInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessagesInfo",
                table: "MessagesInfo");

            migrationBuilder.RenameTable(
                name: "MessagesInfo",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_MessagesInfo_ClientId",
                table: "Messages",
                newName: "IX_Messages_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessagesInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ClientId",
                table: "MessagesInfo",
                newName: "IX_MessagesInfo_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessagesInfo",
                table: "MessagesInfo",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesInfo_Clients_ClientId",
                table: "MessagesInfo",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
