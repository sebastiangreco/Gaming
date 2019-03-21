using SG.Gaming.Helpers;
using SG.Gaming.Models;
using SG.Gaming.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming.ViewModels
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModelBase(string trackPrefix)
            : base(trackPrefix)
        {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            GlobalSetting.Instance.BaseEndpoint = Settings.UrlBase;
            CurrentUser = Settings.UserData;

            //MessagingCenter.Unsubscribe<LoginViewModel>(this, MessageKeys.CurrentUserChange);
            //MessagingCenter.Subscribe<LoginViewModel>(this, MessageKeys.CurrentUserChange, (sender) =>
            //{
            //    CurrentUser = Settings.UserData;
            //    ReloadData();
            //});
        }

        #region Private properties
        private bool _isBusy;
        private LoginResponse _currentUser;
        #endregion

        #region Public properties
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                if (_isBusy == true)
                {
                    DialogService.ShowLoading(Text_Loading);
                }
                else
                {
                    DialogService.HideLoading();
                }
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public LoginResponse CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                RaisePropertyChanged(() => CurrentUser);
            }
        }

        public virtual IGamingApp SGApp
        {
            get
            {
                return Container.SGApp;
            }
        }
        #endregion

        #region Public Methods
        public async Task ShowServiceErrorAlert(ServiceExceptionOptions option)
        {
            switch (option)
            {
                case ServiceExceptionOptions.Comunication:
                    await DialogService.ShowAlertAsync(Text_ServiceErrorDescription, Text_ServiceError, Text_Ok);
                    break;
                case ServiceExceptionOptions.Authentication:
                    await DialogService.ShowAlertAsync(Text_ServiceAuthErrorDescription, Text_ServiceError, Text_Ok);
                    break;
                case ServiceExceptionOptions.Bad_Response:
                    await DialogService.ShowAlertAsync(Text_ServiceResponseErrorDescription, Text_ServiceError, Text_Ok);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Virtual methods
        public virtual void ReloadData()
        {

        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
        #endregion

        #region Application texts
        

        public string Text_Ok
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.GENERAL_Ok, "OK");
            }
        }

        public string Text_Cancel
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.GENERAL_Cancel, "CANCEL");
            }
        }

        public string Text_Loading
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.GENERAL_Loading, "Please wait...");
            }
        }        

        public string Text_ServiceError
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.ERROR_ServiceError, "Service error");
            }
        }

        public string Text_ServiceErrorDescription
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.ERROR_ServiceErrorDescription, "Error retrieving data from service. Try again later");
            }
        }

        public string Text_ServiceAuthErrorDescription
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.ERROR_ServiceAuthErrorDescription, "Authentication error, Try again later, if problem continues please Logout / Login");
            }
        }

        public string Text_ServiceResponseErrorDescription
        {
            get
            {
                return this.SGApp.GetLocalizedText(LanguageToken.ERROR_ServiceResponseErrorDescription, "Bad data retrieved from service, Please try again later");
            }
        }       
        #endregion
    }
}
