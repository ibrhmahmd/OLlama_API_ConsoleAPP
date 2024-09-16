using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAIResponse_EditTokenUsage_FixCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AIResponses_AIResponseID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AIResponses_AIResponseId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "AIModelCategory");

            migrationBuilder.DropTable(
                name: "AIResponses");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_AIResponseId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_AIResponseID",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "TrainingData",
                table: "LanguageModels");

            migrationBuilder.DropColumn(
                name: "AIResponseId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "AIResponseID",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "TokenUsage",
                table: "ChatSessions",
                newName: "contextStringLength");

            migrationBuilder.AlterColumn<string>(
                name: "Parameters",
                table: "LanguageModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "MaxTokens",
                table: "LanguageModels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "LanguageModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatMessageID",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "AIModelID",
                table: "ChatMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LanguageModels_CategoryID",
                table: "LanguageModels",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ChatMessageID",
                table: "Feedbacks",
                column: "ChatMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_AIModelID",
                table: "ChatMessages",
                column: "AIModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserID",
                table: "ChatMessages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserID",
                table: "ChatMessages",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_LanguageModels_AIModelID",
                table: "ChatMessages",
                column: "AIModelID",
                principalTable: "LanguageModels",
                principalColumn: "AIModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_ChatMessages_ChatMessageID",
                table: "Feedbacks",
                column: "ChatMessageID",
                principalTable: "ChatMessages",
                principalColumn: "ChatMessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModels_Categories_CategoryID",
                table: "LanguageModels",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_LanguageModels_AIModelID",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_ChatMessages_ChatMessageID",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModels_Categories_CategoryID",
                table: "LanguageModels");

            migrationBuilder.DropIndex(
                name: "IX_LanguageModels_CategoryID",
                table: "LanguageModels");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ChatMessageID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_AIModelID",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_UserID",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "LanguageModels");

            migrationBuilder.DropColumn(
                name: "ChatMessageID",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "AIModelID",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "contextStringLength",
                table: "ChatSessions",
                newName: "TokenUsage");

            migrationBuilder.AlterColumn<long>(
                name: "Parameters",
                table: "LanguageModels",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MaxTokens",
                table: "LanguageModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "TrainingData",
                table: "LanguageModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AIResponseId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<Guid>(
                name: "AIResponseID",
                table: "ChatMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AIModelCategory",
                columns: table => new
                {
                    CategoriesCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelsAIModelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModelCategory", x => new { x.CategoriesCategoryID, x.ModelsAIModelID });
                    table.ForeignKey(
                        name: "FK_AIModelCategory_Categories_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIModelCategory_LanguageModels_ModelsAIModelID",
                        column: x => x.ModelsAIModelID,
                        principalTable: "LanguageModels",
                        principalColumn: "AIModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AIResponses",
                columns: table => new
                {
                    AIResponseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatSessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatSessionID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponseText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenRate = table.Column<double>(type: "float", nullable: false),
                    Tokens = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIResponses", x => x.AIResponseID);
                    table.ForeignKey(
                        name: "FK_AIResponses_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AIResponses_ChatSessions_ChatSessionID",
                        column: x => x.ChatSessionID,
                        principalTable: "ChatSessions",
                        principalColumn: "ChatSessionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AIResponses_ChatSessions_ChatSessionID1",
                        column: x => x.ChatSessionID1,
                        principalTable: "ChatSessions",
                        principalColumn: "ChatSessionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AIResponseId",
                table: "Feedbacks",
                column: "AIResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_AIResponseID",
                table: "ChatMessages",
                column: "AIResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelCategory_ModelsAIModelID",
                table: "AIModelCategory",
                column: "ModelsAIModelID");

            migrationBuilder.CreateIndex(
                name: "IX_AIResponses_ChatSessionID",
                table: "AIResponses",
                column: "ChatSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_AIResponses_ChatSessionID1",
                table: "AIResponses",
                column: "ChatSessionID1");

            migrationBuilder.CreateIndex(
                name: "IX_AIResponses_UserId1",
                table: "AIResponses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AIResponses_AIResponseID",
                table: "ChatMessages",
                column: "AIResponseID",
                principalTable: "AIResponses",
                principalColumn: "AIResponseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AIResponses_AIResponseId",
                table: "Feedbacks",
                column: "AIResponseId",
                principalTable: "AIResponses",
                principalColumn: "AIResponseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
