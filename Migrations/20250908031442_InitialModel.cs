using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simulado.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fanfics",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fanfics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fanfics_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReadLists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReadLists_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FanficReadList",
                columns: table => new
                {
                    FanficsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanficReadList", x => new { x.FanficsID, x.ListsID });
                    table.ForeignKey(
                        name: "FK_FanficReadList_Fanfics_FanficsID",
                        column: x => x.FanficsID,
                        principalTable: "Fanfics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FanficReadList_ReadLists_ListsID",
                        column: x => x.ListsID,
                        principalTable: "ReadLists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FanficReadList_ListsID",
                table: "FanficReadList",
                column: "ListsID");

            migrationBuilder.CreateIndex(
                name: "IX_Fanfics_OwnerID",
                table: "Fanfics",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadLists_OwnerID",
                table: "ReadLists",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FanficReadList");

            migrationBuilder.DropTable(
                name: "Fanfics");

            migrationBuilder.DropTable(
                name: "ReadLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
