using SG.Gaming.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SG.Gaming.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootView : MasterDetailPage
    {
        public RootView()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            MessagingCenter.Unsubscribe<MenuViewModel>(this, MessageKeys.HideMenu);
            MessagingCenter.Subscribe<MenuViewModel>(this, MessageKeys.HideMenu, (sender) =>
            {
                IsPresented = false;
            });
        }
    }
}