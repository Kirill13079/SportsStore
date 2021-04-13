namespace SportsStore.Infrastructure.Concrete
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}