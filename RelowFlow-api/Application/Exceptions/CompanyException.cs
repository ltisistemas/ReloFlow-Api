namespace RelowFlow_api.Application.Exceptions;

// Exception base/geral
public class CompanyException : Exception
{
    public CompanyException(string message) : base(message)
    {
    }

    public CompanyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

// Usuário não encontrado
public class CompanyNotFoundException : CompanyException
{
    public CompanyNotFoundException()
        : base("Empresa não encontrada.")
    {
    }

    public CompanyNotFoundException(Guid userId)
        : base($"Empresa com ID '{userId}' não encontrada.")
    {
    }
}