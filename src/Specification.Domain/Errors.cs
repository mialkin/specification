namespace Specification.Domain;

public static class Errors
{
    public static class General
    {
        public static Error NotFound()
        {
            return new Error(code: "record.not.found", message: "Record not found");
        }

        public static Error InternalServerError(string message)
        {
            return new Error("internal.server.error", message);
        }
    }

    public static class Movie
    {
        public static Error NameAlreadyExists() =>
            new(code: "movie.name.already.exists", message: "Name already exists");

        public static Error NotSuitableForChildren() =>
            new(code: "movie.not.suitable.for.children", message: "The movie is not suitable for children");

        public static Error DoesNotHaveCdVersion() =>
            new(code: "movie.does.not.have.cd.version", message: "The movie doesn't have a CD version");
    }
}
