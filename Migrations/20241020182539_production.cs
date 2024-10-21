using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gpt_integration.Migrations
{
    /// <inheritdoc />
    public partial class production : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                schema: "gptintegration",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_Chat_ChatId",
                schema: "gptintegration",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                schema: "gptintegration",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                schema: "gptintegration",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                schema: "gptintegration",
                newName: "ChatMessages",
                newSchema: "gptintegration");

            migrationBuilder.RenameTable(
                name: "Chat",
                schema: "gptintegration",
                newName: "Chats",
                newSchema: "gptintegration");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ChatId",
                schema: "gptintegration",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_UserId",
                schema: "gptintegration",
                table: "Chats",
                newName: "IX_Chats_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "gptintegration",
                table: "Chats",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                schema: "gptintegration",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                schema: "gptintegration",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Chats_ChatId",
                schema: "gptintegration",
                table: "ChatMessages",
                column: "ChatId",
                principalSchema: "gptintegration",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserId",
                schema: "gptintegration",
                table: "Chats",
                column: "UserId",
                principalSchema: "gptintegration",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Chats_ChatId",
                schema: "gptintegration",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserId",
                schema: "gptintegration",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                schema: "gptintegration",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                schema: "gptintegration",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "gptintegration",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                schema: "gptintegration",
                newName: "Chat",
                newSchema: "gptintegration");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                schema: "gptintegration",
                newName: "ChatMessage",
                newSchema: "gptintegration");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserId",
                schema: "gptintegration",
                table: "Chat",
                newName: "IX_Chat_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatId",
                schema: "gptintegration",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                schema: "gptintegration",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                schema: "gptintegration",
                table: "ChatMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                schema: "gptintegration",
                table: "Chat",
                column: "UserId",
                principalSchema: "gptintegration",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_Chat_ChatId",
                schema: "gptintegration",
                table: "ChatMessage",
                column: "ChatId",
                principalSchema: "gptintegration",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
