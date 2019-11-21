using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuickCore.Client
{
    public class ClientBase
    {
    }
    public class ClientBase<T> : ClientBase
        where T : class
    {
        public ClientBase(IHttpClientFactory httpClientFactory)
        {
            this.factory = httpClientFactory;
        }
        public Task<HttpResponseMessage> Get(string url, Dictionary<string, string> headers = null)
        {
            var client = this.factory.CreateClient();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress, url)
            };
            if (headers != null)
            {
                foreach (var kv in headers)
                {
                    request.Headers.Add(kv.Key, kv.Value);
                }
            }
            return client.SendAsync(request);
        }
        public async Task<string> GetString(string url, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage res = null;
            try
            {
                res = await this.Get(url, headers);
            }
            catch (Exception ex)
            {

                throw new ApiResponseException("Get api response error.", ex);
            }
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsStringAsync();
        }
        public async Task<Type> GetJsonObject<Type>(string url, Dictionary<string, string> headers = null)
        {
            var text = await GetString(url, headers);
            return JsonConvert.DeserializeObject<Type>(text);
        }

        private IHttpClientFactory factory;
    }
}
