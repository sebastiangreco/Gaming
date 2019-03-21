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
    public class MenuViewModel : ViewModelBase
    {
        #region Constructor
        public MenuViewModel()
            : base("MenuViewModel")
        {
            base.ExecuteMethod("MenuViewModel", delegate ()
            {
                ReloadData();
            });
        }
        #endregion

        #region Overrides
        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        public override void ReloadData()
        {
            base.ExecuteMethod("ReloadData", delegate ()
            {
                if (Settings.UserData == null) return;

                //if (Settings.UserData.userGroup == "XXXX")
                //{
                //    if (GlobalSetting.Instance.MenuDealer != null)
                //        MenuItem = GlobalSetting.Instance.MenuDealer.OrderBy(a => a.Order).ToList();
                //}

            });
        }
        #endregion

        #region Private properties
        private List<MenuOption> _menuItem;
        #endregion

        #region Public properties
        public List<MenuOption> MenuItem
        {
            get
            {
                return _menuItem;
            }
            set
            {
                _menuItem = value;
                RaisePropertyChanged(() => MenuItem);
            }
        }
        #endregion

        #region Commands        
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());
        public ICommand OnSelectedOptionCommand => new Command<MenuOption>(NavigateToSelectedOptionAsync);
        #endregion

        #region Protected Methods
        protected async Task LogoutAsync()
        {
            await base.ExecuteMethodAsync("LogoutAsync", async delegate ()
            {
                MessagingCenter.Send(this, MessageKeys.HideMenu);
                await NavigationService.ShowPopupAsync<LoginViewModel>(new LogoutParameter { Logout = true });
            });
        }

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

                    MessagingCenter.Send(this, MessageKeys.HideMenu);
                }
            });
        }
        #endregion

        #region Screen Text
        public string Text_Title
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.HOME_Title, "Home");
            }
        }

        public string Text_SignOut
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.LOGIN_Logout, "Logout");
            }
        }
        #endregion
    }
}
