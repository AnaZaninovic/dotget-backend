namespace DotGetBackend.Application.Interfaces;

public interface IAuthenticatedUserService
{
    public Guid UserId { get; }
}