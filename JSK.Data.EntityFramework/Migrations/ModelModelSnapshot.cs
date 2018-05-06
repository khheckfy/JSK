﻿// <auto-generated />
using JSK.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JSK.Data.EntityFramework.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JSK.Domain.Entities.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsRandomQuestionsOrder");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("JSK.Domain.Entities.TestQuestion", b =>
                {
                    b.Property<int>("TestQuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSingleAnswer");

                    b.Property<string>("Question")
                        .HasMaxLength(1024);

                    b.Property<int>("TestId");

                    b.HasKey("TestQuestionId");

                    b.HasIndex("TestId");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("JSK.Domain.Entities.TestQuestionAnswer", b =>
                {
                    b.Property<int>("TestQuestionAnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .HasMaxLength(1024);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("TestQuestionId");

                    b.HasKey("TestQuestionAnswerId");

                    b.HasIndex("TestQuestionId");

                    b.ToTable("TestQuestionAnswers");
                });

            modelBuilder.Entity("JSK.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JSK.Domain.Entities.UserTest", b =>
                {
                    b.Property<Guid>("UserTestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("TestId");

                    b.Property<int>("UserId");

                    b.HasKey("UserTestId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTests");
                });

            modelBuilder.Entity("JSK.Domain.Entities.UserTestAnswer", b =>
                {
                    b.Property<int>("UserTestAnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText")
                        .HasMaxLength(1024);

                    b.Property<int?>("TestQuestionAnswerId");

                    b.Property<int>("TestQuestionId");

                    b.Property<int>("UserId");

                    b.Property<Guid?>("UserTestId");

                    b.HasKey("UserTestAnswerId");

                    b.HasIndex("TestQuestionAnswerId");

                    b.HasIndex("TestQuestionId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserTestId");

                    b.ToTable("UserTestAnswers");
                });

            modelBuilder.Entity("JSK.Domain.Entities.TestQuestion", b =>
                {
                    b.HasOne("JSK.Domain.Entities.Test", "Test")
                        .WithMany("TestQuestions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JSK.Domain.Entities.TestQuestionAnswer", b =>
                {
                    b.HasOne("JSK.Domain.Entities.TestQuestion", "TestQuestion")
                        .WithMany("TestQuestionAnswers")
                        .HasForeignKey("TestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JSK.Domain.Entities.UserTest", b =>
                {
                    b.HasOne("JSK.Domain.Entities.Test", "Test")
                        .WithMany("UserTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JSK.Domain.Entities.User", "User")
                        .WithMany("UserTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JSK.Domain.Entities.UserTestAnswer", b =>
                {
                    b.HasOne("JSK.Domain.Entities.TestQuestionAnswer", "TestQuestionAnswer")
                        .WithMany("UserTestAnswers")
                        .HasForeignKey("TestQuestionAnswerId");

                    b.HasOne("JSK.Domain.Entities.TestQuestion", "TestQuestion")
                        .WithMany("UserTestAnswers")
                        .HasForeignKey("TestQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JSK.Domain.Entities.User", "User")
                        .WithMany("UserTestAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JSK.Domain.Entities.UserTest", "UserTest")
                        .WithMany("UserTestAnswers")
                        .HasForeignKey("UserTestId");
                });
#pragma warning restore 612, 618
        }
    }
}
