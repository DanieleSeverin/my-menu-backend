using Application.Abstractions.Messaging;

namespace Application.Businesses.CreateBusiness;

public record CreateBusinessCommand() : ICommand<Guid>;
