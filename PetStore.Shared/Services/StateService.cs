using PetStore.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Shared.Services
{
    public class StateService : IStateService
    {
        public event Action OnChange;
        public bool IsLoggedIn { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? Email { get; private set; }
        public int UserId { get; private set; }

     

        public void SetLoggedInState(bool isLoggedIn, bool isAdmin,string email, int userId)
        {
            IsLoggedIn = isLoggedIn;
            IsAdmin = isAdmin;
            Email = email;
            UserId= userId;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

