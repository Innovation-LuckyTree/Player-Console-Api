using HP_Player_Console.Application.Common.Enums;

namespace HP_Player_Console.Application.Common.Constants;

public static class PaymentMethodConstants
{
    public const string GCash = "GCash";
    public const string Cash = "Cash";
    public const string Bank = "Bank";
    public const string LoadingSystem = "LoadingSystem";

    public static string GetPaymentMethodName(this PaymentMethodTypes paymentMethod)
        => paymentMethod switch
        {
            PaymentMethodTypes.Cash => Cash,
            PaymentMethodTypes.Bank => Bank,
            PaymentMethodTypes.GCash => GCash,
            PaymentMethodTypes.LoadingSystem => LoadingSystem
        };
}