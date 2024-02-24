using AdsML.Application.Common.MLModels;
using AdsML.Application.Common.ViewModels;
using AdsML.Domain.Models.Common;

namespace AdsML.Application.Common.Interfaces;

public interface IPredictRepository
{
   public PredictViewModel Predict(string content);
   public OperationResult RetrainModel(ICollection<ModelInput> command);
}
