using AdsML.Application.Common.Interfaces;
using AdsML.Application.Common.MLModels;
using AdsML.Domain.Models.Common;
using AdsML.Domain.Models.DataSetAgg;
using MapsterMapper;
using MediatR;

namespace AdsML.Application.Notification.Retrain;

public record RetrainNotification : INotification
{

}

public class RetrainNotificationHandler(IAdsDataRepository adsDataRepository,
    IPredictRepository predictRepository,
    IMapper mapper)
    : INotificationHandler<RetrainNotification>
{
    private readonly IAdsDataRepository _adsDataRepository = adsDataRepository;
    private readonly IPredictRepository _predictRepository = predictRepository;
    private readonly IMapper _mapper;
    public async Task Handle(RetrainNotification notification, CancellationToken cancellationToken)
    {
        var dataset = await _adsDataRepository.GetAll(cancellationToken);
        _predictRepository.RetrainModel(_mapper.Map<ICollection<ModelInput>>(dataset));
    }
}

