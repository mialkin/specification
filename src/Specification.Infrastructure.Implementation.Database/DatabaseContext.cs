using Microsoft.EntityFrameworkCore;
using Specification.Domain.Entities;
using Specification.Infrastructure.Implementation.Database.EntityTypeConfigurations;
using Specification.Infrastructure.Interfaces.Database;

namespace Specification.Infrastructure.Implementation.Database;

internal sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options), IDatabaseContext
{
    public DbSet<Director> Directors { get; set; }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorEntityTypeConfiguration());
        SeedTestData(modelBuilder);
    }

    private static void SeedTestData(ModelBuilder modelBuilder)
    {
        var directors = new Director[]
        {
            new()
            {
                Id = new Guid("10B5CEBC-AE88-478C-83A3-A103619EC51D"),
                Name = "Marc Webb"
            },
            new()
            {
                Id = new Guid("EE568809-EEB4-4391-AC0B-6BCC5ABC06E0"),
                Name = "Bill Condon"
            },
            new()
            {
                Id = new Guid("EDBFDAB1-E053-40A4-B904-18D323879CA5"),
                Name = "Chris Renaud"
            },
            new()
            {
                Id = new Guid("D9CFF573-FCFC-4B2A-A84F-5AAC5F04F8C8"),
                Name = "Jon Favreau"
            },
            new()
            {
                Id = new Guid("8D422C65-CE51-4436-9D82-3E0A2185DE93"),
                Name = "M. Night Shyamalan"
            },
            new()
            {
                Id = new Guid("33B8DC82-963B-44EA-915A-1322D565674E"),
                Name = "Alex Kurtzman"
            }
        };

        modelBuilder.Entity<Director>().HasData(directors);

        modelBuilder.Entity<Movie>().HasData([
            new Movie
            {
                Id = new Guid("272B950E-6835-4865-A924-C09750723145"),
                Name = "The Amazing Spider-Man",
                ReleaseDate = new DateTime(2012, 7, 3).ToUniversalTime(),
                MpaaRating = MpaaRating.Pg13,
                Genre = "Adventure",
                Rating = 7,
                DirectorId = directors[0].Id
            },
            new Movie
            {
                Id = new Guid("AD4F3D9B-3D1A-43B7-B408-FDCF157125C2"),
                Name = "Beauty and the Beast",
                ReleaseDate = new DateTime(2017, 3, 17).ToUniversalTime(),
                MpaaRating = MpaaRating.Pg13,
                Genre = "Family",
                Rating = 7.8,
                DirectorId = directors[1].Id
            },
            new Movie
            {
                Id = new Guid("4F8EAB4F-1EB6-49C3-9FCA-F8CFB8CDC149"),
                Name = "The Secret Life of Pets",
                ReleaseDate = new DateTime(2016, 7, 8).ToUniversalTime(),
                MpaaRating = MpaaRating.G,
                Genre = "Adventure",
                Rating = 6.6,
                DirectorId = directors[2].Id
            },
            new Movie
            {
                Id = new Guid("4C5979B4-73AF-49DC-B6EA-B9EED4BDC5CA"),
                Name = "The Jungle Book",
                ReleaseDate = new DateTime(2016, 4, 15).ToUniversalTime(),
                MpaaRating = MpaaRating.Pg,
                Genre = "Fantasy",
                Rating = 7.5,
                DirectorId = directors[3].Id
            },
            new Movie
            {
                Id = new Guid("7D5CBDB0-7068-4D75-8CDC-DA5333CB446A"),
                Name = "Split",
                ReleaseDate = new DateTime(2017, 1, 20).ToUniversalTime(),
                MpaaRating = MpaaRating.Pg13,
                Genre = "Horror",
                Rating = 7.4,
                DirectorId = directors[4].Id
            },
            new Movie
            {
                Id = new Guid("6B125171-4CFC-4937-89CF-4B0D2384201D"),
                Name = "The Mummy",
                ReleaseDate = new DateTime(2017, 6, 9).ToUniversalTime(),
                MpaaRating = MpaaRating.R,
                Genre = "Action",
                Rating = 6.7,
                DirectorId = directors[5].Id
            }
        ]);
    }
}
