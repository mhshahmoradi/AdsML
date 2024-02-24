using AdsML.Application.Common.ViewModels;
using MediatR;

namespace AdsML.Application.UseCase.ML.Commands.Predict;

public record PredictCommand : IRequest<PredictViewModel>
{
    public string Content { get; set; }
}
