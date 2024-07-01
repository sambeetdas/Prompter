using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Prompter.Common
{
    public class ApiManager
    {
        public static async Task<String> Post(string url, string authToken, string request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var postData = new StringContent(request, Encoding.UTF8, "application/json");

                    if (!String.IsNullOrWhiteSpace(authToken))
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.PostAsync(url, postData);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        return response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException e)
                {
                    return e.Message;
                }
            }
        }

        public static async Task<String> Get(string url, string authToken)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    if (!String.IsNullOrWhiteSpace(authToken))
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        return response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException e)
                {
                    return e.Message;
                }
            }
        }
    }
}
