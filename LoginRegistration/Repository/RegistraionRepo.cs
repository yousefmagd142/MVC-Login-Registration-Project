using LoginRegistration.Models;
using LoginRegistration.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography.Xml;

namespace LoginRegistration.Repository
{
    public class RegistraionRepo: IRegistraionRepo
    {
       
        public UserAccount RegisterUser(RegistrationUserModel newUser)
        {
            UserAccount userAccount = new UserAccount
            {
                UserName = newUser.UserName,
                PasswordHash = newUser.Password // Ensure this is set correctly
            };
            return userAccount;
        }
        //public async Task<IdentityResult> RegisterUserAsync(RegistrationUserModel newUser)
        //{
        //   UserAccount userAccount = new UserAccount
        //   {
        //       UserName = newUser.UserName,
        //       PasswordHash = newUser.Password // Ensure this is set correctly
        //   };
        //    // Call CreateAsync with the UserAccount and the password
        //    return userAccount.UserName;
        //}


        //public async Task<IdentityResult> RegisterUserAsync(RegistrationUserModel newUser)
        //{
        //    UserAccount userAccount = new UserAccount
        //    {
        //        UserName = newUser.UserName,
        //        PasswordHash = newUser.Password
        //    };

        //    var result = await _userManager.CreateAsync(newUser,newUser.Password);
        //    return result;
        //}

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, UserAccount item)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public UserAccount LogIn(UserAccount item)
        {
            throw new NotImplementedException();
        }

        
    }
}
