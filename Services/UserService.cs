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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserKey { get; set; }
        public string UserName { get; set; }

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
            //OrgUserServiceDevReference.AuthenticateCorpSvcsRequest authenticateCorpSvcsRequest = new OrgUserServiceDevReference.AuthenticateCorpSvcsRequest();
            //authenticateCorpSvcsRequest.token = authenticationToken;
            //var userAuth = orgUserServiceClient.AuthenticateCorpSvcsAsync(authenticateCorpSvcsRequest).Result;
            OrgUserServiceDevReference.AuthenticateRequest authenticateRequest = new OrgUserServiceDevReference.AuthenticateRequest();
            authenticateRequest.token = authenticationToken;
            var userAuth = orgUserServiceClient.AuthenticateAsync(authenticateRequest).Result;
            //if (userAuth.AuthenticateCorpSvcsResult.IsValid)
            if (userAuth.AuthenticateResult.IsValid)
            {
                User loggedInUser = new User(key);
                user = loggedInUser;
                user.FullName = string.Format("{0} {1}", userAuth.identities[0].OrgUserMapping.UserProfile.ContactFirstName, userAuth.identities[0].OrgUserMapping.UserProfile.ContactLastName);
                user.ContactId = userAuth.identities[0].UserData.ContactID;
                user.OrgUserMappingKey = userAuth.identities[0].OrgUserMapping.OrgUserMappingKey.ToString();
                UserKey = user.OrgUserMappingKey;
                UserName = user.FullName;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public string GetCurrentUserId(){
            var context = _httpContextAccessor.HttpContext;
            var userKey = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
            return userKey;
        }

        public string GetCurrentUserName(){
            return UserName;
        }

        public bool IsUserLoggedIn()
        {
            var context = _httpContextAccessor.HttpContext;
            return context.User.Identities.Any(x => x.IsAuthenticated);
        }
    }
}