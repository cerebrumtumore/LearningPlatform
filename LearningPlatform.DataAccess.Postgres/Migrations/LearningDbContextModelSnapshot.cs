﻿// <auto-generated />
using System;
using LearningPlatform.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningPlatform.DataAccess.Postgres.Migrations
{
    [DbContext(typeof(LearningDbContext))]
    partial class LearningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserAuthorid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthorid");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LessonText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("userId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.user", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("courseuser", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudents", (string)null);
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.course", b =>
                {
                    b.HasOne("LearningPlatform.DataAccess.Postgres.models.user", "UserAuthor")
                        .WithMany("AuthorCourses")
                        .HasForeignKey("UserAuthorid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserAuthor");
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.lesson", b =>
                {
                    b.HasOne("LearningPlatform.DataAccess.Postgres.models.course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningPlatform.DataAccess.Postgres.models.user", null)
                        .WithMany("Lessons")
                        .HasForeignKey("userId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("courseuser", b =>
                {
                    b.HasOne("LearningPlatform.DataAccess.Postgres.models.course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningPlatform.DataAccess.Postgres.models.user", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LearningPlatform.DataAccess.Postgres.models.user", b =>
                {
                    b.Navigation("AuthorCourses");

                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
