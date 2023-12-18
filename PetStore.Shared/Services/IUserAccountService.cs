using PetStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Shared.Services
{
    public interface IUserAccountService
    {
        Task<UserAccount> Login(string email, string password);
        Task<UserAccount> GetUserAccountById(int userId);
        Task<UserAccount> GetUserAccountByEmail(string email);
        Task<UserAccount> AddUserAccount(UserAccount userAccount);
        Task<bool> CheckUserAccountRole(string email);
        Task<List<UserAccount>> GetAllUserAccounts();
        Task<bool> CheckEmailExists(string email);
        Task<UserAccount>GetCart(int userId);
        Task<bool> UpdateAccount(UserAccount userAccount);

        
       
    }
}
