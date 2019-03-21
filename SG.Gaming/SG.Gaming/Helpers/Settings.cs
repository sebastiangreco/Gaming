using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SG.Gaming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string AccessToken = "access_token";
        private const string IdToken = "id_token";
        private const string IdUseMocks = "use_mocks";
        private const string IdUrlBase = "url_base";
        private const string IdUserData = "user_data";
        
        private const string IdInitData = "app_initData";
        private static readonly string AccessTokenDefault = string.Empty;
        private static readonly string IdTokenDefault = string.Empty;
        private static readonly bool UseMocksDefault = GlobalSetting.Instance.UseMocks;
        private static readonly string UrlBaseDefault = GlobalSetting.Instance.BaseEndpoint;
        private static readonly string UserDataDefault = string.Empty;        
        private static readonly string InitDataDefault = null;
        #endregion

        public static string AuthAccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessToken, AccessTokenDefault);
            set => AppSettings.AddOrUpdateValue(AccessToken, value);
        }

        public static string AuthIdToken
        {
            get => AppSettings.GetValueOrDefault(IdToken, IdTokenDefault);
            set => AppSettings.AddOrUpdateValue(IdToken, value);
        }

        public static bool UseMocks
        {
            get => AppSettings.GetValueOrDefault(IdUseMocks, UseMocksDefault);
            set => AppSettings.AddOrUpdateValue(IdUseMocks, value);
        }

        public static string UrlBase
        {
            get => AppSettings.GetValueOrDefault(IdUrlBase, UrlBaseDefault);
            set => AppSettings.AddOrUpdateValue(IdUrlBase, value);
        }

        public static LoginResponse UserData
        {
            get
            {
                string jsonLoginResponse = AppSettings.GetValueOrDefault(IdUserData, UserDataDefault);
                if (!string.IsNullOrEmpty(jsonLoginResponse))
                    return JsonConvert.DeserializeObject<LoginResponse>(jsonLoginResponse);
                else
                    return null;
            }
            set
            {
                string jsonLoginResponse = UserDataDefault;
                if (value != null)
                {
                    LoginResponse loginResponse = (LoginResponse)value;                    
                    jsonLoginResponse = JsonConvert.SerializeObject(value);
                }

                AppSettings.AddOrUpdateValue(IdUserData, jsonLoginResponse);
            }
        }

        public static Tuple<string, string> InitData
        {
            get
            {
                string jsonList = AppSettings.GetValueOrDefault(IdInitData, InitDataDefault);
                if (string.IsNullOrEmpty(jsonList))
                    return null;
                else
                    return JsonConvert.DeserializeObject<Tuple<string, string>>(jsonList);
            }
            set
            {
                string jsonList = InitDataDefault;
                if (value != null)
                    jsonList = JsonConvert.SerializeObject(value);

                AppSettings.AddOrUpdateValue(IdInitData, jsonList);
            }
        }
    }
}
