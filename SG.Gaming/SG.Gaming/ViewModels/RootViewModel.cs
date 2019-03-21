using SG.Gaming.Services.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SG.Gaming.Services;

namespace SG.Gaming.ViewModels
{
    public class RootViewModel : ViewModelBase
    {
        private IUserService _userService;

        public RootViewModel(IUserService userService)
            : base("RootViewModel")
        {
            base.ExecuteMethod("RootViewModel", delegate ()
            {
                this._userService = userService;
            });
        }

        public override Task InitializeAsync(object navigationData)
        {
            ValidateLogin();
            return base.InitializeAsync(navigationData);
        }

        protected async Task ValidateLogin()
        {
            await base.ExecuteMethodAsync("ValidateLogin", async delegate ()
            {
                await NavigationService.ShowPopupAsync<LoginViewModel>();
            });
        }
    }
}
