using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Services
{
    public class UserService : IUserService
    {
        private IDictionary<string, (string PasswordHash, User User)> _users =
            new Dictionary<string, (string PasswordHash, User User)>();

        public string UserKey { get; set; }
        public string UserName { get; set; }

        public UserService(IDictionary<string, string> users)
        {
            foreach (var user in users)
            {
                _users.Add(user.Key.ToLower(), (user.Value, new User(user.Key)));
            }
        }
        public Task<bool> ValidateCredentials(string email, string password, out User user)
        {
            throw new System.NotImplementedException();
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
                user.FullName = string.Format("{0} {1}", userAuth.Result.identities[0].OrgUserMapping.UserProfile.ContactFirstName, userAuth.Result.identities[0].OrgUserMapping.UserProfile.ContactLastName);
                user.ContactId = userAuth.Result.identities[0].UserData.ContactID;
                user.OrgUserMappingKey = userAuth.Result.identities[0].OrgUserMapping.OrgUserMappingKey.ToString();
                UserKey = user.OrgUserMappingKey;
                UserName = user.FullName;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public string GetCurrentUserId(){
            return UserKey;
        }

        public string GetCurrentUserName(){
            return UserName;
        }
    }
}