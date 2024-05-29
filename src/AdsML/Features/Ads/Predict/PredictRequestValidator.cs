namespace AdsML.Features.Ads.Predict;

public class PredictRequestValidator : AbstractValidator<PredictRequest>
{
    public PredictRequestValidator()
    {
        RuleFor(x => x.content)
        .NotNull()
        .NotEmpty()
        .MaximumLength(4824);
    }
}
