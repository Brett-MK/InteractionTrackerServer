using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractionTrackerServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CcNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeWithUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeWithUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    CallId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationId = table.Column<int>(type: "int", nullable: true),
                    WaitingTimeId = table.Column<int>(type: "int", nullable: true),
                    AgentDataId = table.Column<int>(type: "int", nullable: true),
                    CallDataId = table.Column<int>(type: "int", nullable: true),
                    IssueStatus = table.Column<int>(type: "int", nullable: false),
                    CustomerStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.CallId);
                    table.ForeignKey(
                        name: "FK_Interactions_AgentData_AgentDataId",
                        column: x => x.AgentDataId,
                        principalTable: "AgentData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactions_CallData_CallDataId",
                        column: x => x.CallDataId,
                        principalTable: "CallData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactions_TimeWithUnit_DurationId",
                        column: x => x.DurationId,
                        principalTable: "TimeWithUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactions_TimeWithUnit_WaitingTimeId",
                        column: x => x.WaitingTimeId,
                        principalTable: "TimeWithUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_AgentDataId",
                table: "Interactions",
                column: "AgentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_CallDataId",
                table: "Interactions",
                column: "CallDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_DurationId",
                table: "Interactions",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_WaitingTimeId",
                table: "Interactions",
                column: "WaitingTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "AgentData");

            migrationBuilder.DropTable(
                name: "CallData");

            migrationBuilder.DropTable(
                name: "TimeWithUnit");
        }
    }
}
