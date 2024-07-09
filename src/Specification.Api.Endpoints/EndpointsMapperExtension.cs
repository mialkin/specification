using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Specification.Api.Endpoints.Movies.Create;
using Specification.Api.Endpoints.Movies.Delete;
using Specification.Api.Endpoints.Movies.Get;
using Specification.Api.Endpoints.Movies.List;
using Specification.Api.Endpoints.Movies.Search;
using Specification.Api.Endpoints.Movies.Update;
using Specification.Api.Endpoints.Tickets.BuyAdult;
using Specification.Api.Endpoints.Tickets.BuyChild;
using Specification.Api.Endpoints.Tickets.BuyOnCd;

namespace Specification.Api.Endpoints;

public static class EndpointsMapperExtension
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        MapMovieEndpoints(builder);
        MapTicketEndpoints(builder);
    }

    private static void MapMovieEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/movies")
            .WithTags("Movies");

        groupBuilder.MapCreateMovie("/");
        groupBuilder.MapGetMovie("/");
        groupBuilder.MapUpdateMovie("/");
        groupBuilder.MapDeleteMovie("/");
        groupBuilder.MapListMovies("list");
        groupBuilder.MapSearchMovies("search");
    }

    private static void MapTicketEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/tickets")
            .WithTags("Tickets");

        groupBuilder.MapBuyAdultTicket("buyAdult");
        groupBuilder.MapBuyChildTicket("buyChild");
        groupBuilder.MapBuyOnCdTicket("buyOnCd");
    }
}
