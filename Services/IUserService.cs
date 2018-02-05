using System.Threading.Tasks;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentialsAsync(string email, string password, out User user);
        string GetCurrentUserId();
    }
    
}