namespace AcademyApp.Application.Exceptions;

public class EntityDoesNotExistException : Exception
{
    public EntityDoesNotExistException() { }
    public EntityDoesNotExistException(string message) : base(message) { }
    public EntityDoesNotExistException(string message, Exception exception) : base(message, exception) { }
}
