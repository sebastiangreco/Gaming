using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming.Services
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
        
        Task<TResult> PostAsync<TResult>(string uri, string jsonData, string token = "", string header = "");

        Task<TResult> PutAsync<TResult>(string uri, string jsonData, string token = "", string header = "");

        Task DeleteAsync(string uri, string token = "");

        Task<T> ExecuteAsync<T>(RestRequest request) where T : new();
    }
}
