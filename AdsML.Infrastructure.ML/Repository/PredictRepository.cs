using AdsML.Application.Common.Interfaces;
using AdsML.Application.Common.MLModels;
using AdsML.Application.Common.ViewModels;
using AdsML.Domain.Models.Common;
using Microsoft.ML.Trainers;
using Microsoft.ML;
using Microsoft.Extensions.Options;
using Shared;

namespace AdsML.Infrastructure.ML.Repository;

public class PredictRepository
    : IPredictRepository
{
    private readonly AppSetting _options;
    private PredictionEngine<ModelInput, ModelOutput>? _predictEngine;

    public PredictRepository(IOptions<AppSetting> options)
    {
       _options = options.Value;
       _predictEngine = CreatePredictEngine();
    }
    public PredictViewModel Predict(string content)
    {
        var result = _predictEngine?.Predict(new(content));

        return new(result.PredictedLabel, result.Score[0]);
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
            return OperationResult.Failed(ApplicationMessages.OperationFailed);
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
    private PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
    {
        MLContext mlContext = new();
        ITransformer mlModel = mlContext.Model.Load(_options.ModelFilePath, out _);

        return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }
}
