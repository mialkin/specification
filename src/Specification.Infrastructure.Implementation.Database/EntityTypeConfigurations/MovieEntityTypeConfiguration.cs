using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.Domain.Entities;

namespace Specification.Infrastructure.Implementation.Database.EntityTypeConfigurations;

internal class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => new { x.Id });
        builder.HasIndex(x => new { x.Name }).IsUnique();
    }
}
