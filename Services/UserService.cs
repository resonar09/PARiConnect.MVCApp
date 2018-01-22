using System.Collections.Generic;
using System.Threading.Tasks;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Services
{
    public class UserService : IUserService
    {
        private IDictionary<string, (string PasswordHash, User User)> _users =
            new Dictionary<string, (string PasswordHash, User User)>();

        public UserService(IDictionary<string, string> users)
        {
            foreach (var user in users)
            {
                _users.Add(user.Key.ToLower(), (user.Value, new User(user.Key)));
            }
        }
        public Task<bool> ValidateCredentialsAsync(string email, string password, out User user)
        {
            user = null;
            var key = email.ToLower();
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            OrgUserServiceDevReference.AuthenticationToken authenticationToken = new OrgUserServiceDevReference.AuthenticationToken();
            authenticationToken.EmailAddress = email;
            authenticationToken.Password = password;
            OrgUserServiceDevReference.AuthenticateCorpSvcsRequest authenticateCorpSvcsRequest = new OrgUserServiceDevReference.AuthenticateCorpSvcsRequest();
            authenticateCorpSvcsRequest.token = authenticationToken;
            var userAuth = orgUserServiceClient.AuthenticateCorpSvcsAsync(authenticateCorpSvcsRequest);
            if (userAuth.Result.AuthenticateCorpSvcsResult.IsValid)
            {
                User loggedInUser = new User(key);
                user = loggedInUser;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}