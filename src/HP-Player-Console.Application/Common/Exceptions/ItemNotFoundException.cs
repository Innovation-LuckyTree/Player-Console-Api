namespace HP_Player_Console.Application.Common.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string errorMessage)
        : base(errorMessage) { }
}