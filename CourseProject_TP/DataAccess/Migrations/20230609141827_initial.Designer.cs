﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(FootballHelperDbContext))]
    [Migration("20230609141827_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataAccess.Entities.ClubEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GameSessionEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionEntityId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("DataAccess.Entities.GameSessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FirstClubResult")
                        .HasColumnType("int");

                    b.Property<int>("SecondClubResult")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentEntityId");

                    b.ToTable("GameSession");
                });

            modelBuilder.Entity("DataAccess.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClubEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubEntityId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("DataAccess.Entities.TournamentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("DataAccess.Entities.ClubEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.GameSessionEntity", null)
                        .WithMany("Clubs")
                        .HasForeignKey("GameSessionEntityId");
                });

            modelBuilder.Entity("DataAccess.Entities.GameSessionEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.TournamentEntity", null)
                        .WithMany("GameSessions")
                        .HasForeignKey("TournamentEntityId");
                });

            modelBuilder.Entity("DataAccess.Entities.PlayerEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.ClubEntity", null)
                        .WithMany("Players")
                        .HasForeignKey("ClubEntityId");
                });

            modelBuilder.Entity("DataAccess.Entities.ClubEntity", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DataAccess.Entities.GameSessionEntity", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("DataAccess.Entities.TournamentEntity", b =>
                {
                    b.Navigation("GameSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
