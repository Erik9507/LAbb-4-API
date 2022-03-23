﻿// <auto-generated />
using LAbb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LAbb_4_API.Migrations
{
    [DbContext(typeof(ProgramDbContext))]
    partial class ProgramDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LAbb_4_API.Models.Interests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestDescription = "Padel is a racquet sport that combines the elements of tennis, squash and badminton.",
                            InterestName = "Padel",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            InterestDescription = "A sport in which participants climb up, down or across natural rock formations or artificial rock walls.",
                            InterestName = "Rock climbing",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            InterestDescription = "Coding makes it possible for us to create computer software, games, apps and websites.",
                            InterestName = "Coding",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 4,
                            InterestDescription = "Surfing is the sport of riding waves in an upright or prone position. Surfers catch the ocean, river, or man-made waves and glide across the surface",
                            InterestName = "Surfing",
                            PersonId = 4
                        });
                });

            modelBuilder.Entity("LAbb_4_API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Viktor",
                            PhoneNumber = "0701234599"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lukas",
                            PhoneNumber = "0704593288"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Erik",
                            PhoneNumber = "0707842511"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Simon",
                            PhoneNumber = "0738432077"
                        });
                });

            modelBuilder.Entity("LAbb_4_API.Models.WebbAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<string>("WebbSiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Webbadress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestsId");

                    b.ToTable("WebbAdresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestsId = 1,
                            WebbSiteName = "World Padel Tour",
                            Webbadress = "https://www.worldpadeltour.com/en"
                        },
                        new
                        {
                            Id = 2,
                            InterestsId = 2,
                            WebbSiteName = "Climb Europe",
                            Webbadress = "https://climb-europe.com/"
                        },
                        new
                        {
                            Id = 3,
                            InterestsId = 3,
                            WebbSiteName = "Code Cademy",
                            Webbadress = "https://www.codecademy.com/"
                        },
                        new
                        {
                            Id = 4,
                            InterestsId = 4,
                            WebbSiteName = "Surfer Today",
                            Webbadress = "https://www.surfertoday.com/"
                        });
                });

            modelBuilder.Entity("LAbb_4_API.Models.Interests", b =>
                {
                    b.HasOne("LAbb_4_API.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LAbb_4_API.Models.WebbAdress", b =>
                {
                    b.HasOne("LAbb_4_API.Models.Interests", "Interests")
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
