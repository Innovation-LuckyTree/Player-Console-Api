namespace HP_Player_Console.Application.Common.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string name, object key)
        : base($"Entity '{name}' ({key}) was not found.") { }
}