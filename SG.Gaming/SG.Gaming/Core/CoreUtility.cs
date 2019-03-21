using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming
{
    public static class CoreUtility
    {
        public static void ExecuteMethod(string name, Action method, Action<Exception> onError = null, bool supressMethodLogging = false)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                Container.Track.LogError(ex, name);
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    HandleException(ex);
                }
            }
        }

        public static async Task ExecuteMethodAsync(string name, Func<Task> method, Action<Exception> onError = null, bool supressMethodLogging = false)
        {
            try
            {
                await method();
            }
            catch (Exception ex)
            {
                Container.Track.LogError(ex, name);
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    HandleException(ex);
                }
            }
        }

        public static T ExecuteFunction<T>(string name, Func<T> method, Action<Exception> onError = null, bool supressMethodLogging = false)
        {
            try
            {
                return method();
            }
            catch (Exception ex)
            {
                Container.Track.LogError(ex, name);
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    HandleException(ex);
                }
                return default(T);
            }
        }
        public static async Task<T> ExecuteFunctionAsync<T>(string name, Func<Task<T>> method, Action<Exception> onError = null)
        {
            try
            {
                return await method();
            }
            catch (Exception ex)
            {
                Container.Track.LogError(ex, name);
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    HandleException(ex);
                }
                return default(T);
            }
        }

        public static void HandleException(Exception ex)
        {
            AggregateException aggregate = ex as AggregateException;
            if (aggregate != null)
            {
                foreach (var item in aggregate.InnerExceptions)
                {
                    HandleException(item);
                }
                return;
            }
        }
    }
}
