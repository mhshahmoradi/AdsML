using AdsML.Application.Notification.Retrain;
using MediatR;

namespace ServiceHost.Common;

public class BackgroundTask(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;
    public async Task Retrain()
    {
        await _mediator.Publish(new RetrainNotification());
    }
}
