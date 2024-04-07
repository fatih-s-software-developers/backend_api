﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend_api.DataAccess.Concretes;

#nullable disable

namespace backend_api.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20240407174835_StudentTable")]
    partial class StudentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend_api.DataAccess.Concretes.StudentDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("teacherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("teacherId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("backend_api.DataAccess.Concretes.TeacherDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TeacherDbModel");
                });

            modelBuilder.Entity("backend_api.DataAccess.Concretes.StudentDbModel", b =>
                {
                    b.HasOne("backend_api.DataAccess.Concretes.TeacherDbModel", "teacher")
                        .WithOne("student")
                        .HasForeignKey("backend_api.DataAccess.Concretes.StudentDbModel", "teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("backend_api.DataAccess.Concretes.TeacherDbModel", b =>
                {
                    b.Navigation("student")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
