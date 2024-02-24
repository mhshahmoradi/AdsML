using AdsML.Application.Common.Interfaces;
using AdsML.Application.Common.ViewModels;
using AdsML.Domain.Models.DataSetAgg;
using MapsterMapper;
using MediatR;

namespace AdsML.Application.UseCase.ML.Commands.Predict;

public class PredictCommandHandler(ICacheProvider cacheProvider,
    IPredictRepository predictRepository,
    IAdsDataRepository adsDataRepository)
    : IRequestHandler<PredictCommand, PredictViewModel>
{
    private readonly ICacheProvider _cacheProvider = cacheProvider;
    private readonly IPredictRepository _predictRepository = predictRepository;
    private readonly IAdsDataRepository _adsDataRepository = adsDataRepository;

    public async Task<PredictViewModel> Handle(PredictCommand request, CancellationToken cancellationToken)
    {
        var result = _cacheProvider.TryGet(request.Content);

        if (result.Result)
            return result.Data;

        var predictedLabel = _predictRepository.Predict(request.Content);

        _cacheProvider.Set(request.Content, predictedLabel);

        await _adsDataRepository.Add(new(label: predictedLabel.label, content: request.Content), cancellationToken);

        return predictedLabel;
    }
}
