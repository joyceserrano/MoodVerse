﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodVerse.Repository;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoodVerse.Data.Entity.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Lookups.PrimaryEmotionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PrimaryEmotionType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8218caf3-2f43-4f25-8d93-a3799d4ed4b1"),
                            Deleted = false,
                            Name = "Happy",
                            Order = 1
                        },
                        new
                        {
                            Id = new Guid("2ecd6a10-9b48-4ace-b067-41e64970b652"),
                            Deleted = false,
                            Name = "Sad",
                            Order = 2
                        },
                        new
                        {
                            Id = new Guid("aabd1cf6-9828-4d67-9a24-3fe8084a5259"),
                            Deleted = false,
                            Name = "Disgusted",
                            Order = 3
                        },
                        new
                        {
                            Id = new Guid("f2a3fc65-5a98-4363-8103-4d0b30c9df45"),
                            Deleted = false,
                            Name = "Angry",
                            Order = 4
                        },
                        new
                        {
                            Id = new Guid("d3b6f6ba-0720-437d-80ec-edf9b463e469"),
                            Deleted = false,
                            Name = "Fearful",
                            Order = 5
                        },
                        new
                        {
                            Id = new Guid("9eb10e85-9dee-4cd4-b181-e8142dfe2ddc"),
                            Deleted = false,
                            Name = "Bad",
                            Order = 6
                        },
                        new
                        {
                            Id = new Guid("c9157a17-c48c-4f92-946f-dcb13d0b9199"),
                            Deleted = false,
                            Name = "Surprised",
                            Order = 7
                        });
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrimaryEmotionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.HasIndex("PrimaryEmotionTypeId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Quote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ModifierId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Account", b =>
                {
                    b.HasOne("MoodVerse.Data.Entity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "User")
                        .WithOne()
                        .HasForeignKey("MoodVerse.Data.Entity.Account", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Modifier");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Artist", b =>
                {
                    b.HasOne("MoodVerse.Data.Entity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Note", b =>
                {
                    b.HasOne("MoodVerse.Data.Entity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.Lookups.PrimaryEmotionType", "PrimaryEmotionType")
                        .WithMany()
                        .HasForeignKey("PrimaryEmotionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Modifier");

                    b.Navigation("PrimaryEmotionType");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.Quote", b =>
                {
                    b.HasOne("MoodVerse.Data.Entity.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoodVerse.Data.Entity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Artist");

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("MoodVerse.Data.Entity.User", b =>
                {
                    b.HasOne("MoodVerse.Data.Entity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MoodVerse.Data.Entity.User", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Modifier");
                });
#pragma warning restore 612, 618
        }
    }
}
