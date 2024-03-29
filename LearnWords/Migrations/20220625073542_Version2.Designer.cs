﻿// <auto-generated />
using LearnWords.Model.DBEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnWords.Migrations
{
    [DbContext(typeof(ContextApp))]
    [Migration("20220625073542_Version2")]
    partial class Version2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearnWords.Model.DBEntity.Clases.FutureSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedENUA")
                        .HasColumnType("int");

                    b.Property<int>("CompletedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("ENFutureContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENFuturePerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENFuturePerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENFutureSimple")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedENUA")
                        .HasColumnType("int");

                    b.Property<int>("FailedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("UAFutureContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAFuturePerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAFuturePerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAFutureSimple")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ENFutureSimple" }, "FutureSentence_Index")
                        .IsUnique()
                        .HasFilter("[ENFutureSimple] IS NOT NULL");

                    b.ToTable("FutureSentences");
                });

            modelBuilder.Entity("LearnWords.Model.DBEntity.Clases.PastSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedENUA")
                        .HasColumnType("int");

                    b.Property<int>("CompletedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("ENPastContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPastPerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPastPerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPastSimple")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedENUA")
                        .HasColumnType("int");

                    b.Property<int>("FailedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("UAPastContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPastPerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPastPerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPastSimple")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ENPastSimple" }, "PastSentence_Index")
                        .IsUnique()
                        .HasFilter("[ENPastSimple] IS NOT NULL");

                    b.ToTable("PastSentences");
                });

            modelBuilder.Entity("LearnWords.Model.DBEntity.Clases.PresentSentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedENUA")
                        .HasColumnType("int");

                    b.Property<int>("CompletedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("ENPresentContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPresentPerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPresentPerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENPresentSimple")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedENUA")
                        .HasColumnType("int");

                    b.Property<int>("FailedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("UAPresentContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPresentPerfect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPresentPerfectContinuous")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAPresentSimple")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ENPresentSimple" }, "PresentSentence_Index")
                        .IsUnique()
                        .HasFilter("[ENPresentSimple] IS NOT NULL");

                    b.ToTable("PresentSentences");
                });

            modelBuilder.Entity("LearnWords.Model.DBEntity.Clases.Sentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedENUA")
                        .HasColumnType("int");

                    b.Property<int>("CompletedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("ENSentence")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedENUA")
                        .HasColumnType("int");

                    b.Property<int>("FailedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("UASentence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ENSentence" }, "Sentence_Index")
                        .IsUnique()
                        .HasFilter("[ENSentence] IS NOT NULL");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("LearnWords.Model.DBEntity.Clases.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedENUA")
                        .HasColumnType("int");

                    b.Property<int>("CompletedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("ENWord")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FailedENUA")
                        .HasColumnType("int");

                    b.Property<int>("FailedUAEN")
                        .HasColumnType("int");

                    b.Property<string>("SecondForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UAWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ENWord" }, "Word_Index")
                        .IsUnique()
                        .HasFilter("[ENWord] IS NOT NULL");

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
