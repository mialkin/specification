﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Specification.Infrastructure.Implementation.Database;

#nullable disable

namespace Specification.Infrastructure.Implementation.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240711213127_Add_Directors_Table")]
    partial class Add_Directors_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Specification.Domain.Entities.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_directors");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_directors_name");

                    b.ToTable("directors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10b5cebc-ae88-478c-83a3-a103619ec51d"),
                            Name = "Marc Webb"
                        },
                        new
                        {
                            Id = new Guid("ee568809-eeb4-4391-ac0b-6bcc5abc06e0"),
                            Name = "Bill Condon"
                        },
                        new
                        {
                            Id = new Guid("edbfdab1-e053-40a4-b904-18d323879ca5"),
                            Name = "Chris Renaud"
                        },
                        new
                        {
                            Id = new Guid("d9cff573-fcfc-4b2a-a84f-5aac5f04f8c8"),
                            Name = "Jon Favreau"
                        },
                        new
                        {
                            Id = new Guid("8d422c65-ce51-4436-9d82-3e0a2185de93"),
                            Name = "M. Night Shyamalan"
                        },
                        new
                        {
                            Id = new Guid("33b8dc82-963b-44ea-915a-1322d565674e"),
                            Name = "Alex Kurtzman"
                        });
                });

            modelBuilder.Entity("Specification.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uuid")
                        .HasColumnName("director_id");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genre");

                    b.Property<int>("MpaaRating")
                        .HasColumnType("integer")
                        .HasColumnName("mpaa_rating");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.HasKey("Id")
                        .HasName("pk_movies");

                    b.HasIndex("DirectorId")
                        .HasDatabaseName("ix_movies_director_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_movies_name");

                    b.ToTable("movies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("272b950e-6835-4865-a924-c09750723145"),
                            DirectorId = new Guid("10b5cebc-ae88-478c-83a3-a103619ec51d"),
                            Genre = "Adventure",
                            MpaaRating = 3,
                            Name = "The Amazing Spider-Man",
                            Rating = 7.0,
                            ReleaseDate = new DateTime(2012, 7, 2, 20, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ad4f3d9b-3d1a-43b7-b408-fdcf157125c2"),
                            DirectorId = new Guid("ee568809-eeb4-4391-ac0b-6bcc5abc06e0"),
                            Genre = "Family",
                            MpaaRating = 3,
                            Name = "Beauty and the Beast",
                            Rating = 7.7999999999999998,
                            ReleaseDate = new DateTime(2017, 3, 16, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("4f8eab4f-1eb6-49c3-9fca-f8cfb8cdc149"),
                            DirectorId = new Guid("edbfdab1-e053-40a4-b904-18d323879ca5"),
                            Genre = "Adventure",
                            MpaaRating = 1,
                            Name = "The Secret Life of Pets",
                            Rating = 6.5999999999999996,
                            ReleaseDate = new DateTime(2016, 7, 7, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("4c5979b4-73af-49dc-b6ea-b9eed4bdc5ca"),
                            DirectorId = new Guid("d9cff573-fcfc-4b2a-a84f-5aac5f04f8c8"),
                            Genre = "Fantasy",
                            MpaaRating = 2,
                            Name = "The Jungle Book",
                            Rating = 7.5,
                            ReleaseDate = new DateTime(2016, 4, 14, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("7d5cbdb0-7068-4d75-8cdc-da5333cb446a"),
                            DirectorId = new Guid("8d422c65-ce51-4436-9d82-3e0a2185de93"),
                            Genre = "Horror",
                            MpaaRating = 3,
                            Name = "Split",
                            Rating = 7.4000000000000004,
                            ReleaseDate = new DateTime(2017, 1, 19, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("6b125171-4cfc-4937-89cf-4b0d2384201d"),
                            DirectorId = new Guid("33b8dc82-963b-44ea-915a-1322d565674e"),
                            Genre = "Action",
                            MpaaRating = 4,
                            Name = "The Mummy",
                            Rating = 6.7000000000000002,
                            ReleaseDate = new DateTime(2017, 6, 8, 21, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("Specification.Domain.Entities.Movie", b =>
                {
                    b.HasOne("Specification.Domain.Entities.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_movies_directors_director_id");

                    b.Navigation("Director");
                });
#pragma warning restore 612, 618
        }
    }
}
