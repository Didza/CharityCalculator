using System.Threading.Tasks;
using CharityCalculator.UI.Models;

namespace CharityCalculator.UI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM registration);
        Task Logout();
    }
}
