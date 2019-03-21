using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SG.Gaming
{
    public static class CommonResources
    {
        public static string LogoImagePath
        {
            get
            {
                string imagePath = "";
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        imagePath = "logo.png";
                        break;
                    case Device.iOS:
                        imagePath = "logo.png";
                        break;
                    default:
                        break;
                }
                return imagePath;
            }
        }
    }
}
