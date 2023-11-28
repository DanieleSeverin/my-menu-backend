using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Businesses;

namespace Application.Businesses.CreateBusiness;

internal sealed class CreateBusinessCommandHandler : ICommandHandler<CreateBusinessCommand, Guid>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBusinessCommandHandler(IBusinessRepository businessRepository, 
                                        IUnitOfWork unitOfWork)
    {
        _businessRepository = businessRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        Business business = new Business();

        _businessRepository.Add(business);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(business.Id.Value);
    }
}
