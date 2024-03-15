﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreServices.API.Author.Infrastructure;

namespace StoreServices.API.Author.Migrations
{
    [DbContext(typeof(AuthorContext))]
    partial class AuthorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StoreServices.API.Author.Models.AcademicState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AcademicDegree")
                        .HasColumnType("integer");

                    b.Property<Guid>("AcademicStateRepresentative")
                        .HasColumnType("uuid");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Institute")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("AcademicStates");
                });

            modelBuilder.Entity("StoreServices.API.Author.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("AuthorRepresentative")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BornDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("StoreServices.API.Author.Models.AcademicState", b =>
                {
                    b.HasOne("StoreServices.API.Author.Models.Author", "Author")
                        .WithMany("AcademicStates")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
