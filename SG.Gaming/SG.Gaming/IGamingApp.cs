using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SG.Gaming
{
    public interface IGamingApp
    {
        Page CurrentPage { get; set; }
        RestClient ServiceClient { get; set; }

        string GetLocalizedText(LanguageToken token, string defaultText);
    }
}
