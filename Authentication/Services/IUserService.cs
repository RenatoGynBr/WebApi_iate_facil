
namespace WebApi_iate_facil.Authentication.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}
