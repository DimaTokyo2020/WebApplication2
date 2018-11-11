﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MoodTubeOriginal.Data;
using System;

namespace MoodTubeOriginal.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoodTubeOriginal.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserLocation");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Mood", b =>
                {
                    b.Property<string>("MoodID")
                        .HasMaxLength(50);

                    b.Property<string>("MoodName");

                    b.HasKey("MoodID");

                    b.ToTable("Mood");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Singer", b =>
                {
                    b.Property<string>("SingerID")
                        .HasMaxLength(50);

                    b.Property<string>("SingerName")
                        .HasMaxLength(50);

                    b.HasKey("SingerID");

                    b.ToTable("Singer");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Song", b =>
                {
                    b.Property<string>("SongID")
                        .HasMaxLength(50);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MoodID")
                        .HasMaxLength(50);

                    b.Property<string>("SingerID")
                        .HasMaxLength(50);

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SongID");

                    b.HasIndex("MoodID");

                    b.HasIndex("SingerID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Tour", b =>
                {
                    b.Property<string>("TourID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("SingerID");

                    b.Property<DateTime>("When");

                    b.HasKey("TourID");

                    b.HasIndex("SingerID");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Song", b =>
                {
                    b.HasOne("MoodTubeOriginal.Models.Mood", "Mood")
                        .WithMany("Songs")
                        .HasForeignKey("MoodID");

                    b.HasOne("MoodTubeOriginal.Models.Singer", "Singer")
                        .WithMany("Songs")
                        .HasForeignKey("SingerID");
                });

            modelBuilder.Entity("MoodTubeOriginal.Models.Tour", b =>
                {
                    b.HasOne("MoodTubeOriginal.Models.Singer", "Singer")
                        .WithMany()
                        .HasForeignKey("SingerID");
                });
#pragma warning restore 612, 618
        }
    }
}
