namespace HP_Player_Console.Application.Common.Exceptions;

public class GameScheduleException(string errorMessage) : Exception($"{errorMessage}")
{
}