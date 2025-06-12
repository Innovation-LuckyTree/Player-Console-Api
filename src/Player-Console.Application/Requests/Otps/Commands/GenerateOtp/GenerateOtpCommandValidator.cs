using FluentValidation;

namespace HP_Player_Console.Application.Requests.Otps.Commands.GenerateOtp;

public class GenerateOtpCommandValidator : AbstractValidator<GenerateOtpCommand>
{
    public GenerateOtpCommandValidator()
    {
        RuleFor(o => o.MobileNumber)
            .NotEmpty()
            .Length(11);
    }
}
