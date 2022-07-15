using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWords.Migrations
{
    public partial class Version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Word_Index",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "Sentence_Index",
                table: "Sentences");

            migrationBuilder.DropIndex(
                name: "PresentSentence_Index",
                table: "PresentSentences");

            migrationBuilder.DropIndex(
                name: "PastSentence_Index",
                table: "PastSentences");

            migrationBuilder.DropIndex(
                name: "FutureSentence_Index",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "UAPresentContinuous",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "UAPresentPerfect",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "UAPresentPerfectContinuous",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "UAPresentSimple",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "UAPastContinuous",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "UAPastPerfect",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "UAPastPerfectContinuous",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "UAPastSimple",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "UAFutureContinuous",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "UAFuturePerfect",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "UAFuturePerfectContinuous",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "UAFutureSimple",
                table: "FutureSentences");

            migrationBuilder.AlterColumn<string>(
                name: "UAWord",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENWord",
                table: "Words",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UASentence",
                table: "Sentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "Sentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "Sentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENSentence",
                table: "Sentences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "Sentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "Sentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "PresentSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPresent",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPastSimple",
                table: "PastSentences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "PastSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPast",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "FutureSentences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAFuture",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "Word_Index",
                table: "Words",
                column: "ENWord",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Sentence_Index",
                table: "Sentences",
                column: "ENSentence",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PresentSentence_Index",
                table: "PresentSentences",
                column: "ENPresentSimple",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PastSentence_Index",
                table: "PastSentences",
                column: "ENPastSimple",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FutureSentence_Index",
                table: "FutureSentences",
                column: "ENFutureSimple",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Word_Index",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "Sentence_Index",
                table: "Sentences");

            migrationBuilder.DropIndex(
                name: "PresentSentence_Index",
                table: "PresentSentences");

            migrationBuilder.DropIndex(
                name: "PastSentence_Index",
                table: "PastSentences");

            migrationBuilder.DropIndex(
                name: "FutureSentence_Index",
                table: "FutureSentences");

            migrationBuilder.DropColumn(
                name: "UAPresent",
                table: "PresentSentences");

            migrationBuilder.DropColumn(
                name: "UAPast",
                table: "PastSentences");

            migrationBuilder.DropColumn(
                name: "UAFuture",
                table: "FutureSentences");

            migrationBuilder.AlterColumn<string>(
                name: "UAWord",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "Words",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "Words",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ENWord",
                table: "Words",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "Words",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "Words",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UASentence",
                table: "Sentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "Sentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "Sentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ENSentence",
                table: "Sentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "Sentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "Sentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "PresentSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "PresentSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "PresentSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "PresentSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UAPresentContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPresentPerfect",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPresentPerfectContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "PastSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "PastSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ENPastSimple",
                table: "PastSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "PastSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "PastSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UAPastContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPastPerfect",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPastPerfectContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAPastSimple",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FailedUAEN",
                table: "FutureSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FailedENUA",
                table: "FutureSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ENFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedUAEN",
                table: "FutureSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompletedENUA",
                table: "FutureSentences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UAFutureContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAFuturePerfect",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAFuturePerfectContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UAFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "Word_Index",
                table: "Words",
                column: "ENWord",
                unique: true,
                filter: "[ENWord] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Sentence_Index",
                table: "Sentences",
                column: "ENSentence",
                unique: true,
                filter: "[ENSentence] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "PresentSentence_Index",
                table: "PresentSentences",
                column: "ENPresentSimple",
                unique: true,
                filter: "[ENPresentSimple] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "PastSentence_Index",
                table: "PastSentences",
                column: "ENPastSimple",
                unique: true,
                filter: "[ENPastSimple] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "FutureSentence_Index",
                table: "FutureSentences",
                column: "ENFutureSimple",
                unique: true,
                filter: "[ENFutureSimple] IS NOT NULL");
        }
    }
}
