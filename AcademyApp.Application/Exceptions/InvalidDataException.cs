namespace AcademyApp.Application.Exceptions;

public class InvalidDataException : Exception
{
    public InvalidDataException() : base() { }
    public InvalidDataException(string message) : base(message) { }
    public InvalidDataException(string message, Exception exception) : base(message, exception) { }
}
