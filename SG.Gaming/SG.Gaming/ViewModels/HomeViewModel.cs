using SG.Gaming.Helpers;
using SG.Gaming.Models;
using SG.Gaming.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SG.Gaming.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Constructor
        public HomeViewModel()
            : base("HomeViewModel")
        {
            base.ExecuteMethod("HomeViewModel", delegate ()
            {
                ReloadData();   
                //sebastian
            });
        }
        #endregion

        #region Overrides
        public override void ReloadData()
        {
            base.ExecuteMethod("ReloadData", delegate ()
            {
                //if (Settings.UserData != null)
                //{
                //    if (Settings.UserData.userGroup == "DEALERSHIP")
                //        HomeOption = GlobalSetting.Instance.MenuDealer.OrderBy(a => a.Order).ToList();
                    
                //}
            });
        }
        #endregion

        #region Private properties
        private List<MenuOption> _homeOption;
        #endregion

        #region Public properties
        public List<MenuOption> HomeOption
        {
            get
            {
                return _homeOption;
            }
            set
            {
                _homeOption = value;
                RaisePropertyChanged(() => HomeOption);
            }
        }
        #endregion

        #region Commands        
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());
        public ICommand OnSelectedOptionCommand => new Command<MenuOption>(NavigateToSelectedOptionAsync);
        #endregion

        #region Protected methods
        private async void NavigateToSelectedOptionAsync(MenuOption menuOption)
        {
            await base.ExecuteMethodAsync("NavigateToSelectedOptionAsync", async delegate ()
            {
                if (menuOption != null)
                {
                    switch (menuOption.Key)
                    {
                        //case MenuOptionToken.DEALER_GatePass:
                        //    await NavigationService.NavigateToAsync<ScannerViewModel>();
                        //    break;                        
                        default:
                            break;
                    }                    
                }
            });
        }
        
        protected async Task LogoutAsync()
        {
            await base.ExecuteMethodAsync("LogoutAsync", async delegate ()
            {
                await NavigationService.ShowPopupAsync<LoginViewModel>(new LogoutParameter { Logout = true });
            });
        }
        #endregion

        #region Screen text
        public string Text_Title
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.HOME_Title, "Home");
            }
        }
        #endregion
    }
}
