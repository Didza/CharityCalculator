using System.Threading.Tasks;
using CharityCalculator.Application.Models.Identity;

namespace CharityCalculator.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);

    }
}
