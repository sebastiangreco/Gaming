using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming
{
    public class GlobalSetting
    {
        public const string AzureTag = "Azure";
        public const string MockTag = "Mock";
        public const string ProductionEndpoint = "";
        public const string TestingEndonit = "";
        public const string AppName = "SGAPP";
        public const string AppStorePackageName = "com.SG.app";

        public int AsyncTimeoutMillisecond;

        private string _baseEndpoint;
        private static readonly GlobalSetting _instance = new GlobalSetting();

        public GlobalSetting()
        {
            BaseEndpoint = ProductionEndpoint;
#if DEBUG
            BaseEndpoint = TestingEndonit;
#endif
            this.AsyncTimeoutMillisecond = (int)TimeSpan.FromSeconds(15).TotalMilliseconds;
            
        }

        public static GlobalSetting Instance
        {
            get { return _instance; }
        }

        #region User & App Settings
        public bool UseMocks { get; set; }
        #endregion

        #region Endpoints
        public string BaseEndpoint
        {
            get { return _baseEndpoint; }
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }
        #endregion

        private void UpdateEndpoint(string baseEndpoint)
        {
            
        }
    }
}
