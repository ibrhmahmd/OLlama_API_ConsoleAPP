using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixingChatMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_LanguageModels_AIModelID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_LanguageModels_ModelUsedAIModelID",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModels_AspNetUsers_UserId",
                table: "LanguageModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModels_Categories_CategoryID",
                table: "LanguageModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Prompts_LanguageModels_LanguageModelAIModelID",
                table: "Prompts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "LanguageModels",
                newName: "AIModels");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageModels_UserId",
                table: "AIModels",
                newName: "IX_AIModels_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageModels_CategoryID",
                table: "AIModels",
                newName: "IX_AIModels_CategoryID");

            migrationBuilder.AddColumn<string>(
                name: "AIResponse",
                table: "ChatMessages",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "From",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserMessage",
                table: "ChatMessages",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AIModels",
                table: "AIModels",
                column: "AIModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AIModels_AspNetUsers_UserId",
                table: "AIModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AIModels_Categories_CategoryID",
                table: "AIModels",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AIModels_AIModelID",
                table: "ChatMessages",
                column: "AIModelID",
                principalTable: "AIModels",
                principalColumn: "AIModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_AIModels_ModelUsedAIModelID",
                table: "ChatSessions",
                column: "ModelUsedAIModelID",
                principalTable: "AIModels",
                principalColumn: "AIModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prompts_AIModels_LanguageModelAIModelID",
                table: "Prompts",
                column: "LanguageModelAIModelID",
                principalTable: "AIModels",
                principalColumn: "AIModelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIModels_AspNetUsers_UserId",
                table: "AIModels");

            migrationBuilder.DropForeignKey(
                name: "FK_AIModels_Categories_CategoryID",
                table: "AIModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AIModels_AIModelID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatSessions_AIModels_ModelUsedAIModelID",
                table: "ChatSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prompts_AIModels_LanguageModelAIModelID",
                table: "Prompts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AIModels",
                table: "AIModels");

            migrationBuilder.DropColumn(
                name: "AIResponse",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "From",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "UserMessage",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "AIModels",
                newName: "LanguageModels");

            migrationBuilder.RenameIndex(
                name: "IX_AIModels_UserId",
                table: "LanguageModels",
                newName: "IX_LanguageModels_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AIModels_CategoryID",
                table: "LanguageModels",
                newName: "IX_LanguageModels_CategoryID");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageModels",
                table: "LanguageModels",
                column: "AIModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_LanguageModels_AIModelID",
                table: "ChatMessages",
                column: "AIModelID",
                principalTable: "LanguageModels",
                principalColumn: "AIModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatSessions_LanguageModels_ModelUsedAIModelID",
                table: "ChatSessions",
                column: "ModelUsedAIModelID",
                principalTable: "LanguageModels",
                principalColumn: "AIModelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModels_AspNetUsers_UserId",
                table: "LanguageModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModels_Categories_CategoryID",
                table: "LanguageModels",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prompts_LanguageModels_LanguageModelAIModelID",
                table: "Prompts",
                column: "LanguageModelAIModelID",
                principalTable: "LanguageModels",
                principalColumn: "AIModelID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
