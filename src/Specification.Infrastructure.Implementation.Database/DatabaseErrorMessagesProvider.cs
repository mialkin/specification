using Specification.Infrastructure.Interfaces.Database;

namespace Specification.Infrastructure.Implementation.Database;

public class DatabaseErrorMessagesProvider : IDatabaseErrorMessagesProvider
{
    public string MovieNameUniquenessViolation => "duplicate key value violates unique constraint \"ix_movies_name\"";
}
