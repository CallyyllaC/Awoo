using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Awoo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TTRPGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTRPGs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Availibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabletopSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameMasterId = table.Column<int>(type: "int", nullable: false),
                    NextSession = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabletopSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabletopSessions_TTRPGs_GameId",
                        column: x => x.GameId,
                        principalTable: "TTRPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<int>(type: "int", nullable: false),
                    TabletopSessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TabletopSessions_TabletopSessionId",
                        column: x => x.TabletopSessionId,
                        principalTable: "TabletopSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TTRPGs",
                columns: new[] { "Id", "Colour", "Name" },
                values: new object[,]
                {
                    { 1, -65536, "Cyberpunk" },
                    { 2, -23296, "Pathfinder 2e" },
                    { 3, -16776961, "Dungeons And Dragons" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Colour", "Password", "TabletopSessionId", "Username" },
                values: new object[,]
                {
                    { 1, -2354116, "", null, "Cali" },
                    { 2, -16728065, "", null, "Bali" },
                    { 3, -1644806, "", null, "foreverDM" }
                });

            migrationBuilder.InsertData(
                table: "Availibility",
                columns: new[] { "Id", "DateTime", "Duration", "PlayerId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 6, 13, 18, 8, 35, DateTimeKind.Local).AddTicks(8558), new TimeSpan(2, 0, 0, 0, 0), 1, (byte)1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(2, 0, 0, 0, 0), 2, (byte)0 },
                    { 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(2, 0, 0, 0, 0), 3, (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "TabletopSessions",
                columns: new[] { "Id", "GameId", "GameMasterId", "Name", "NextSession" },
                values: new object[,]
                {
                    { 1, 1, 3, "Cyberpunk Sunday", new DateTime(2023, 7, 6, 13, 18, 8, 35, DateTimeKind.Local).AddTicks(8480) },
                    { 2, 2, 3, "Pathfinder Saturdays", new DateTime(2023, 7, 6, 13, 18, 8, 35, DateTimeKind.Local).AddTicks(8540) },
                    { 3, 3, 3, "Dungeons And Dragons Fridays", new DateTime(2023, 7, 6, 13, 18, 8, 35, DateTimeKind.Local).AddTicks(8544) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availibility_PlayerId",
                table: "Availibility",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TabletopSessions_GameId",
                table: "TabletopSessions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TabletopSessions_GameMasterId",
                table: "TabletopSessions",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TabletopSessionId",
                table: "Users",
                column: "TabletopSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availibility_Users_PlayerId",
                table: "Availibility",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TabletopSessions_Users_GameMasterId",
                table: "TabletopSessions",
                column: "GameMasterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabletopSessions_Users_GameMasterId",
                table: "TabletopSessions");

            migrationBuilder.DropTable(
                name: "Availibility");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TabletopSessions");

            migrationBuilder.DropTable(
                name: "TTRPGs");
        }
    }
}
