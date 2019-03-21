using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SG.Gaming.ViewModels;

namespace SG.Gaming.Services
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task ShowPopupAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task PopCurrentViewAsync();

        Task PopModalViewAsync();

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task ShowPopupAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
