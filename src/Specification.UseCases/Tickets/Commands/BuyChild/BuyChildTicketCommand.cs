using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;

namespace Specification.UseCases.Tickets.Commands.BuyChild;

public record BuyChildTicketCommand(Guid MovieId) : IRequest<Result<Maybe<BuyChildTicketDto>, Error>>;
