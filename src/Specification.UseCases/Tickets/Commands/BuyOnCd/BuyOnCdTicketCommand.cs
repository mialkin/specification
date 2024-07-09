using CSharpFunctionalExtensions;
using MediatR;
using Specification.Domain;

namespace Specification.UseCases.Tickets.Commands.BuyOnCd;

public record BuyOnCdTicketCommand(Guid MovieId) : IRequest<Result<Maybe<BuyOnCdTicketDto>, Error>>;
