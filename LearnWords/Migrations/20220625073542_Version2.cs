using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnWords.Migrations
{
    public partial class Version2 : Migration
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

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "Words",
                newName: "CompletedUAEN");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "Words",
                newName: "CompletedENUA");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "Sentences",
                newName: "CompletedUAEN");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "Sentences",
                newName: "CompletedENUA");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "PresentSentences",
                newName: "CompletedUAEN");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "PresentSentences",
                newName: "CompletedENUA");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "PastSentences",
                newName: "CompletedUAEN");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "PastSentences",
                newName: "CompletedENUA");

            migrationBuilder.RenameColumn(
                name: "SuccesfulUAEN",
                table: "FutureSentences",
                newName: "CompletedUAEN");

            migrationBuilder.RenameColumn(
                name: "SuccesfulENUA",
                table: "FutureSentences",
                newName: "CompletedENUA");

            migrationBuilder.AlterColumn<string>(
                name: "UAWord",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ThirdForm",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondForm",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENWord",
                table: "Words",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UASentence",
                table: "Sentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENSentence",
                table: "Sentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentPerfectContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentPerfect",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentPerfectContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentPerfect",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPastSimple",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPastPerfectContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPastPerfect",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAPastContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPastSimple",
                table: "PastSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPastPerfectContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPastPerfect",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENPastContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAFuturePerfectContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAFuturePerfect",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UAFutureContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ENFuturePerfectContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENFuturePerfect",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ENFutureContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.RenameColumn(
                name: "CompletedUAEN",
                table: "Words",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "CompletedENUA",
                table: "Words",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "CompletedUAEN",
                table: "Sentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "CompletedENUA",
                table: "Sentences",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "CompletedUAEN",
                table: "PresentSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "CompletedENUA",
                table: "PresentSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "CompletedUAEN",
                table: "PastSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "CompletedENUA",
                table: "PastSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.RenameColumn(
                name: "CompletedUAEN",
                table: "FutureSentences",
                newName: "SuccesfulUAEN");

            migrationBuilder.RenameColumn(
                name: "CompletedENUA",
                table: "FutureSentences",
                newName: "SuccesfulENUA");

            migrationBuilder.AlterColumn<string>(
                name: "UAWord",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThirdForm",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondForm",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "UASentence",
                table: "Sentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentSimple",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentPerfectContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentPerfect",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPresentContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentPerfectContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentPerfect",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPresentContinuous",
                table: "PresentSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPastSimple",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPastPerfectContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPastPerfect",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAPastContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "ENPastPerfectContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPastPerfect",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENPastContinuous",
                table: "PastSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAFutureSimple",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAFuturePerfectContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAFuturePerfect",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UAFutureContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "ENFuturePerfectContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENFuturePerfect",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENFutureContinuous",
                table: "FutureSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
