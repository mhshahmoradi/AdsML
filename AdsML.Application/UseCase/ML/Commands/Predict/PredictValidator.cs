using FluentValidation;
using Shared;

namespace AdsML.Application.UseCase.ML.Commands.Predict;

public class PredictValidator : AbstractValidator<PredictCommand>
{
    public PredictValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage(ApplicationMessages.EmptyField);
    }
}
