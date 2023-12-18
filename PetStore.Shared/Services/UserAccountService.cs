using Microsoft.EntityFrameworkCore;
using PetStore.Shared.Data;
using PetStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Shared.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly DataContext _context;
        public UserAccountService(DataContext context) 
        { 
            _context = context;
        }
        public async Task<UserAccount> AddUserAccount(UserAccount userAccount)
        {
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return userAccount;
        }

       
        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.UserAccounts.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CheckUserAccountRole(string email)
        {
            var userAccount = await _context.UserAccounts.FindAsync(email);

            if (userAccount.Role == "Admin")
            {
                return true;
            }
            return false;
        }

        public Task<List<UserAccount>> GetAllUserAccounts()
        {
            var userAccounts = _context.UserAccounts.ToListAsync();
            return userAccounts;
        }

        public async Task<UserAccount> GetCart(int userId)
        {
            try
            {
                var user = await _context.UserAccounts.Include(u => u.Cart).FirstOrDefaultAsync(u => u.UserID == userId);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserAccount> GetUserAccountByEmail(string email)
        {
            return await _context.UserAccounts.FindAsync(email);
        }

        public async Task<UserAccount> GetUserAccountById(int userId)
        {
            return await _context.UserAccounts.FindAsync(userId);
           
        }

        public async Task<UserAccount> Login(string email, string password)
        {
            var userAccount = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);

            if (userAccount == null)
            {
                return null;
            }

            if (userAccount.Password != password)
            {
                return null;
            }

            return userAccount;
        }


        public async Task<bool> UpdateAccount(UserAccount user)
        {
            try
            {
                _context.UserAccounts.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }      
    }



}
