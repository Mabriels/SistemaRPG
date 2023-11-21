namespace SistemaRPG.Exceptions;

public class EmailExistenteException : Exception
{
    public EmailExistenteException() : base("Email já cadastrado!")
    {

    }
}
