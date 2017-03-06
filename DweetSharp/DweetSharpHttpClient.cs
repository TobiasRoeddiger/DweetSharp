using System.Net.Http;
using System.Threading.Tasks;

#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.

namespace DweetSharp
{
    public class DweetSharpHttpClient
    {
        private HttpClient _httpClient;

        public DweetSharpHttpClient()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<string> GETWithContentReturned(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            var responseContent = await response.Content.ReadAsStringAsync();

            //weird behaviour of dweet.io where on failure a 200 status code is returned, therefore have to check if JSON matches failure JSON.
            if (response.IsSuccessStatusCode && !responseContent.StartsWith("{\"this\":\"failed\""))
            {
                return responseContent;
            }
            throw new GETRequestFailedException(response.StatusCode.ToString(), responseContent);
        }

        public async Task<bool> GETWithDidSucceedReturned(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            return await ValidateResponse(response);
        }

        public async Task<bool> POSTWithDidSucceedReturned(string uri, string json)
        {
            var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, stringContent);

            return await ValidateResponse(response);
        }

        private async Task<bool> ValidateResponse(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            //weird behaviour of dweet.io where on failure a 200 status code is returned, therefore have to check if JSON matches failure JSON.
            return response.IsSuccessStatusCode && !responseContent.StartsWith("{\"this\":\"failed\"");
        }
    }
}
