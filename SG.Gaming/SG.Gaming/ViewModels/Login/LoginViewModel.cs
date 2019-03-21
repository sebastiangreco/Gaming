using SG.Gaming.Services.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Private properties        
        private IUserService _userService;        
        #endregion

        #region Constructor
        public LoginViewModel(IUserService userService)
            : base("LoginViewModel")
        {
            base.ExecuteMethod("LoginViewModel", delegate ()
            {                
                this._userService = userService;                
            });
        }
        #endregion
    }
}
