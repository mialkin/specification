using CSharpFunctionalExtensions;
using MediatR;

namespace Specification.UseCases.Tickets.Commands.BuyAdult;

public record BuyAdultTicketCommand(Guid MovieId) : IRequest<Maybe<BuyAdultTicketDto>>;
