using LoginRegistration.Models;
using LoginRegistration.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Repository
{
    public interface IRegistraionRepo
    {
        //Task<IdentityResult> RegisterUserAsync(RegistrationUserModel newUser);
        public UserAccount RegisterUser(RegistrationUserModel item);
        public UserAccount LogIn(UserAccount item);
        public UserAccount GetAccount(int id);
        public void Edit(int id, UserAccount item);
        public void Delete(int id);
    }
}