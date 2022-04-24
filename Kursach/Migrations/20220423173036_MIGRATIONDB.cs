using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kursach.Migrations
{
    public partial class MIGRATIONDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "FineThem",
                columns: table => new
                {
                    Fine_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fine_Text = table.Column<string>(type: "nchar(350)", fixedLength: true, maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDD_Fine", x => x.Fine_id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Login_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login_name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Passwords = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Login_id);
                });

            migrationBuilder.CreateTable(
                name: "PDD_Info",
                columns: table => new
                {
                    PDD_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PDD_Text = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    PDD_img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDD_Info", x => x.PDD_id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_results",
                columns: table => new
                {
                    Ticket_result = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_results", x => x.Ticket_result);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_result = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Exam_id);
                    table.ForeignKey(
                        name: "FK_Exam_Exam_results",
                        column: x => x.Exam_result,
                        principalTable: "Exam_results",
                        principalColumn: "Exam_Results");
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    FineId = table.Column<int>(type: "int", nullable: false),
                    FineThemId = table.Column<int>(type: "int", nullable: false),
                    Fine_Text = table.Column<string>(type: "nchar(350)", fixedLength: true, maxLength: 350, nullable: true),
                    Fine_Cost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_Fine_FineThem",
                        column: x => x.FineThemId,
                        principalTable: "FineThem",
                        principalColumn: "Fine_id");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Admin_id = table.Column<int>(type: "int", nullable: false),
                    Login_id = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Patronim = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Phone_Number = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Date_of_entry = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Admin_id);
                    table.ForeignKey(
                        name: "FK__Admin__Login_id__38996AB5",
                        column: x => x.Login_id,
                        principalTable: "Login",
                        principalColumn: "Login_id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket_result = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Ticket_id);
                    table.ForeignKey(
                        name: "FK_Ticket_Ticket_results",
                        column: x => x.Ticket_result,
                        principalTable: "Ticket_results",
                        principalColumn: "Ticket_result");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Login_id = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Patronim = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Results = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Exam = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK__Users__Login_id__52593CB8",
                        column: x => x.Login_id,
                        principalTable: "Login",
                        principalColumn: "Login_id");
                    table.ForeignKey(
                        name: "FK_Users_Exam_results",
                        column: x => x.Exam,
                        principalTable: "Exam_results",
                        principalColumn: "Exam_Results");
                    table.ForeignKey(
                        name: "FK_Users_Ticket_results",
                        column: x => x.Results,
                        principalTable: "Ticket_results",
                        principalColumn: "Ticket_result");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Question_id = table.Column<int>(type: "int", nullable: false),
                    Question_text = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    Right_answer = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Answer_1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Answer_2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Answer_3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ticket_id = table.Column<int>(type: "int", nullable: false),
                    Question_img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Question_id);
                    table.ForeignKey(
                        name: "FK_Question_Ticket",
                        column: x => x.ticket_id,
                        principalTable: "Ticket",
                        principalColumn: "Ticket_id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket_Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket_id = table.Column<int>(type: "int", nullable: true),
                    Exam_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Ticket_Ex__Exam___44FF419A",
                        column: x => x.Exam_id,
                        principalTable: "Exam",
                        principalColumn: "Exam_id");
                    table.ForeignKey(
                        name: "FK_Ticket_Exam_Ticket",
                        column: x => x.Ticket_id,
                        principalTable: "Ticket",
                        principalColumn: "Ticket_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Login_id",
                table: "Admin",
                column: "Login_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Exam_result",
                table: "Exam",
                column: "Exam_result");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_FineThemId",
                table: "Fine",
                column: "FineThemId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ticket_id",
                table: "Question",
                column: "ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Ticket_result",
                table: "Ticket",
                column: "Ticket_result");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Exam_Exam_id",
                table: "Ticket_Exam",
                column: "Exam_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Exam_Ticket_id",
                table: "Ticket_Exam",
                column: "Ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Exam",
                table: "Users",
                column: "Exam");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login_id",
                table: "Users",
                column: "Login_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Results",
                table: "Users",
                column: "Results");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "PDD_Info");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Ticket_Exam");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FineThem");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Exam_results");

            migrationBuilder.DropTable(
                name: "Ticket_results");
        }
    }
}
