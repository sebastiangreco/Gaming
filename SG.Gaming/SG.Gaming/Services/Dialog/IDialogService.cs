using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);

        Task<bool> ShowConfirmationAsync(string message, string title);

        void ShowToast(string message, int seconds = 1, ToastPosition position = ToastPosition.Top);

        Task<string> ShowActionSheetAsync(string title, string cancel, List<string> buttons);

        void ShowLoading(string title);

        void HideLoading();
    }
}
