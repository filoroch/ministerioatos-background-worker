public class DomainNotFound : DomainException
{
    public DomainNotFound()
    {
    }

    public DomainNotFound(string? message) : base(message)
    {
    }
}