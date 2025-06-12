namespace HP_Player_Console.Application.Common.Constants;

//TODO: this should be remove and change into db query
public class GameTypesConstants
{
    public const int REGULAR = 2;
    public const int POWERWIN = 5;
    public const int TRIPPLEWIN = 7;
    public const int MAGICWIN = 8;
}

public static class CompanyGameConstants
{
    public const int REGULAR = 1;
    public const int POWERWIN = 2;
    public const int TRIPPLEWIN = 3;
    public const int MAGICWIN = 8;

    public static int GetGameTypeFromCompanyGame(this int companyGame)
    {
        return companyGame switch
        {
            REGULAR => GameTypesConstants.REGULAR,
            POWERWIN => GameTypesConstants.POWERWIN,
            TRIPPLEWIN => GameTypesConstants.TRIPPLEWIN,
            MAGICWIN => GameTypesConstants.MAGICWIN,
            _ => 0
        };
    }
}

