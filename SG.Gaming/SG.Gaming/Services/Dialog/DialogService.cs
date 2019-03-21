using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming.Services
{
    public class DialogService : IDialogService, IDisposable
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public Task<bool> ShowConfirmationAsync(string message, string title)
        {
            ConfirmConfig config = new ConfirmConfig();
            config.Title = title;
            config.Message = message;
            config.CancelText = Container.SGApp.GetLocalizedText(LanguageToken.GENERAL_No, "No");
            config.OkText = Container.SGApp.GetLocalizedText(LanguageToken.GENERAL_Yes, "Yes");

            return UserDialogs.Instance.ConfirmAsync(config);
        }

        public void ShowToast(string message, int seconds = 1, ToastPosition position = ToastPosition.Top)
        {
            ToastConfig cn = new ToastConfig(message);
            cn.Position = position;
            cn.SetDuration(seconds * 1000);
            UserDialogs.Instance.Toast(cn);
        }

        public Task<string> ShowActionSheetAsync(string title, string cancel, List<string> buttons)
        {
            return UserDialogs.Instance.ActionSheetAsync(title, cancel, "", null, buttons.ToArray());
        }

        public void ShowLoading(string title)
        {
            UserDialogs.Instance.ShowLoading(title, MaskType.Black);

        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
