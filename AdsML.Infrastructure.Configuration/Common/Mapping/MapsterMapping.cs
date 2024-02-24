using AdsML.Application.Common.MLModels;
using AdsML.Application.Notification.AddDataset;
using AdsML.Domain.Models.DataSetAgg;
using Mapster;

namespace ServiceHost.Common.Mapping
{
    public class MapsterMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddDatasetNotification, AdsData>();

            config.NewConfig<AdsData, ModelInput>();
        }
    }
}
