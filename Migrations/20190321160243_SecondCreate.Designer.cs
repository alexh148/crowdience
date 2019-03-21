﻿// <auto-generated />
using Crowdience.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace crowdience.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20190321160243_SecondCreate")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Crowdience.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("coupleOne");

                    b.Property<string>("coupleTwo");

                    b.Property<bool>("inProgress");

                    b.Property<string>("uniqueID");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Crowdience.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("questionNumber");

                    b.Property<string>("questionTitle");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Crowdience.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.Property<int>("VoteOne");

                    b.Property<int>("VoteTwo");

                    b.Property<string>("coupleOne");

                    b.Property<string>("coupleTwo");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Crowdience.Models.Question", b =>
                {
                    b.HasOne("Crowdience.Models.Game", "Game")
                        .WithMany("Questions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Crowdience.Models.Vote", b =>
                {
                    b.HasOne("Crowdience.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
