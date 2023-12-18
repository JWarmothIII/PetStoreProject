using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Shared.Services
{
    public interface IStateService
    {
        event Action OnChange;
        bool IsLoggedIn { get; }
        bool IsAdmin { get; }
        string Email { get; }
        int UserId { get; }

        void SetLoggedInState(bool isLoggedIn, bool isAdmin, string email, int UserId);
    }
}
