using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SG.Gaming.Models;

namespace SG.Gaming.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            this._requestProvider = requestProvider;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            //request.Resource = GlobalSetting.Instance.LoginEndpoint;
            //request.AddJsonBody(auth);
            return await _requestProvider.ExecuteAsync<LoginResponse>(request);
        }
    }
}
