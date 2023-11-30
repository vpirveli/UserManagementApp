namespace Domain.Exceptions;

public class NotFoundException(string error) : Exception (error)
{

}
