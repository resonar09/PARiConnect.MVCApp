using System.Collections.Generic;
using System.Threading.Tasks;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Services
{
    public class UserServiceMock : IUserService
    {
        private IDictionary<string, (string PasswordHash, User User)> _users =
            new Dictionary<string, (string PasswordHash, User User)>();

        public UserServiceMock(IDictionary<string, string> users)
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
            if (_users.ContainsKey(key))
            {
                var hash = _users[key].PasswordHash;
                if(password == hash)
                {
                 User loggedInUser = new User(key,"Test Name", "12345", "37");
                    user = loggedInUser;
                    //user = _users[key].User;
                    return Task.FromResult(true);
                }
                

            }
            return Task.FromResult(false);
        }
    }
}