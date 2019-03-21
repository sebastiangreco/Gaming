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
	public partial class LoginView : ContentPage
	{
        #region Constructor
        public LoginView()
        {
            InitializeComponent();
        }
        #endregion

        #region Overrides
        protected override void OnAppearing()
        {
            CoreUtility.ExecuteMethod("OnAppearing", delegate ()
            {
                base.OnAppearing();
                NavigationPage.SetHasNavigationBar(this, false);
            });
        }
        #endregion
    }
}