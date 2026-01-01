namespace RelowFlow_api.Application.Exceptions;

// Exception base/geral
public class UserException : Exception
{
    public UserException(string message) : base(message)
    {
    }

    public UserException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

// Email já existe
public class EmailExistsException : UserException
{
    public EmailExistsException(string email)
        : base($"O email '{email}' já está cadastrado no sistema.")
    {
    }
}

// Email não encontrado
public class EmailNotFoundException : UserException
{
    public EmailNotFoundException(string email)
        : base($"Email '{email}' não encontrado.")
    {
    }
}

// Usuário não encontrado
public class UserNotFoundException : UserException
{
    public UserNotFoundException()
        : base("Usuário não encontrado.")
    {
    }

    public UserNotFoundException(Guid userId)
        : base($"Usuário com ID '{userId}' não encontrado.")
    {
    }
}

// NIF já existe
public class NifExistsException : UserException
{
    public NifExistsException(string nif)
        : base($"O NIF '{nif}' já está cadastrado no sistema.")
    {
    }
}

// Email não encontrado
public class UserOrPasswordNotFoundException : UserException
{
    public UserOrPasswordNotFoundException()
        : base("Usuário ou Senha Invalidos")
    {
    }
}