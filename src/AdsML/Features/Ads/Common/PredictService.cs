using AdsML.Common.Shared;
using AdsML.Features.Ads.Common.AdsMLModels;
using Microsoft.Extensions.ML;
using Microsoft.Extensions.Options;
using Microsoft.ML;
using Microsoft.ML.Trainers;

namespace AdsML;

public class PredictService(PredictionEngine<ModelInput,ModelOutput> predictionEngine, IOptions<AppSetting> options)
{
    private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine = predictionEngine;
    private readonly AppSetting _options = options.Value;

    internal PredictResponse Predict(PredictModel predictModel)
    {
        var model = new ModelInput(predictModel.content);
        var response = _predictionEngine.Predict(model);
        return response.ToPredictResponse();
    }
    public OperationResult RetrainModel(ICollection<ModelInput> command)
    {
        MLContext mlContext = new();
        try
        {
            var Data = mlContext.Data.LoadFromEnumerable(command);

            var model = RetrainPipeline(mlContext, Data);

            mlContext.Model.Save(model, Data.Schema, _options.ModelFilePath);

            return OperationResult.Succeeded();
        }
        catch
        {
            return OperationResult.Failed("The operation failed.");
        }
    }
    private IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
    {
        var pipeline = mlContext.Transforms.Text.FeaturizeText(inputColumnName: @"Content", outputColumnName: @"Content")
            .Append(mlContext.Transforms.Concatenate(@"Features", new[] { @"Content" }))
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: @"Label", inputColumnName: @"Label"))
            .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))
            .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(new LbfgsMaximumEntropyMulticlassTrainer.Options() { L1Regularization = 0.03125F, L2Regularization = 0.2431656F, LabelColumnName = @"Label", FeatureColumnName = @"Features" }))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: @"PredictedLabel", inputColumnName: @"PredictedLabel"));
        return pipeline;
    }
    private ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
    {
        var pipeline = BuildPipeline(mlContext);
        var model = pipeline.Fit(trainData);

        return model;
    }
}
