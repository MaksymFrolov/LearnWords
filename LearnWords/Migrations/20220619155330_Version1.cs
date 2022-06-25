using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWords.Migrations
{
    public partial class Version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Succesful",
                table: "Words",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "Failed",
                table: "Words",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "Succesful",
                table: "PresentSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "Failed",
                table: "PresentSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "Succesful",
                table: "PastSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "Failed",
                table: "PastSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "Succesful",
                table: "FutureSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "Failed",
                table: "FutureSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.AddColumn<int>(
                name: "FailedENUA",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedUAEN",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedENUA",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedUAEN",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedENUA",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedUAEN",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedENUA",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailedUAEN",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENSentence = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UASentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccesfulENUA = table.Column<int>(type: "int", nullable: false),
                    FailedENUA = table.Column<int>(type: "int", nullable: false),
                    SuccesfulUAEN = table.Column<int>(type: "int", nullable: false),
                    FailedUAEN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Sentence_Index",
                table: "Sentences",
                column: "ENSentence",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropColumn(
                name: "FailedENUA",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "FailedUAEN",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "FailedENUA",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "FailedUAEN",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "FailedENUA",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "FailedUAEN",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "FailedENUA",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "FailedUAEN",
                table: "FutureSentences");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "Words",
                newName: "Succesful");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "Words",
                newName: "Failed");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "PresentSentences",
                newName: "Succesful");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "PresentSentences",
                newName: "Failed");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "PastSentences",
                newName: "Succesful");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "PastSentences",
                newName: "Failed");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "FutureSentences",
                newName: "Succesful");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "FutureSentences",
                newName: "Failed");
        }
    }
}
