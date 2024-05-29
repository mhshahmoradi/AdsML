using AdsML.Common.Filters;
using AdsML.Features.Ads.Common;
using AdsML.Features.Ads.Common.AdsMLModels;
using Carter;

namespace AdsML.Features.Ads.Predict;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGroup(FeatureManager.Prefix)
            .WithTags(FeatureManager.EndpointTagName)
            .MapPost("/Predict",
            (PredictRequest predictRequest, [FromServices] PredictService _service, CancellationToken cancellationToken) => 
            {
                var request = new PredictModel(predictRequest.content);
                var response = _service.Predict(request);
                return response;
            }).Validator<PredictRequest>();
    }
}
