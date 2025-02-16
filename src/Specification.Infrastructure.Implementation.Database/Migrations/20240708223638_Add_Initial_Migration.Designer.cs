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
    [Migration("20240708223638_Add_Initial_Migration")]
    partial class Add_Initial_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Specification.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_movies_name");

                    b.ToTable("movies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("272b950e-6835-4865-a924-c09750723145"),
                            Genre = "Adventure",
                            MpaaRating = 3,
                            Name = "The Amazing Spider-Man",
                            Rating = 7.0,
                            ReleaseDate = new DateTime(2012, 7, 2, 20, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ad4f3d9b-3d1a-43b7-b408-fdcf157125c2"),
                            Genre = "Family",
                            MpaaRating = 3,
                            Name = "Beauty and the Beast",
                            Rating = 7.7999999999999998,
                            ReleaseDate = new DateTime(2017, 3, 16, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("4f8eab4f-1eb6-49c3-9fca-f8cfb8cdc149"),
                            Genre = "Adventure",
                            MpaaRating = 1,
                            Name = "The Secret Life of Pets",
                            Rating = 6.5999999999999996,
                            ReleaseDate = new DateTime(2016, 7, 7, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("4c5979b4-73af-49dc-b6ea-b9eed4bdc5ca"),
                            Genre = "Fantasy",
                            MpaaRating = 2,
                            Name = "The Jungle Book",
                            Rating = 7.5,
                            ReleaseDate = new DateTime(2016, 4, 14, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("7d5cbdb0-7068-4d75-8cdc-da5333cb446a"),
                            Genre = "Horror",
                            MpaaRating = 3,
                            Name = "Split",
                            Rating = 7.4000000000000004,
                            ReleaseDate = new DateTime(2017, 1, 19, 21, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("6b125171-4cfc-4937-89cf-4b0d2384201d"),
                            Genre = "Action",
                            MpaaRating = 4,
                            Name = "The Mummy",
                            Rating = 6.7000000000000002,
                            ReleaseDate = new DateTime(2017, 6, 8, 21, 0, 0, 0, DateTimeKind.Utc)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
