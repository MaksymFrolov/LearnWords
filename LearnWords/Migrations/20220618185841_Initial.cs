using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWords.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FutureSentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENFutureSimple = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENFutureContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENFuturePerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENFuturePerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAFutureSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAFutureContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAFuturePerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAFuturePerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Succesful = table.Column<int>(type: "int", nullable: false),
                    Failed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureSentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastSentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENPastSimple = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENPastContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENPastPerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENPastPerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPastSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPastContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPastPerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPastPerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Succesful = table.Column<int>(type: "int", nullable: false),
                    Failed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastSentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresentSentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENPresentSimple = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENPresentContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENPresentPerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENPresentPerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPresentSimple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPresentContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPresentPerfect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAPresentPerfectContinuous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Succesful = table.Column<int>(type: "int", nullable: false),
                    Failed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentSentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENWord = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Succesful = table.Column<int>(type: "int", nullable: false),
                    Failed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "FutureSentence_Index",
                table: "FutureSentences",
                column: "ENFutureSimple",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PastSentence_Index",
                table: "PastSentences",
                column: "ENPastSimple",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PresentSentence_Index",
                table: "PresentSentences",
                column: "ENPresentSimple",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Word_Index",
                table: "Words",
                column: "ENWord",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureSentences");

            migrationBuilder.DropTable(
                name: "PastSentences");

            migrationBuilder.DropTable(
                name: "PresentSentences");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
