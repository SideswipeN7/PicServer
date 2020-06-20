using RestSharp;
using System.Threading.Tasks;

namespace Pic.Shared.ApiClient
{
    public class Client
    {
        private readonly RestClient restClient;
        public Client(string baseUrl)
        {
            restClient = new RestClient(baseUrl);
        }

        public async Task<T> Post<T>(string url, object body) => await ExecuteRequest<T>(url, body, Method.POST);

        public async Task<T> Put<T>(string url, object body) => await ExecuteRequest<T>(url, body, Method.PUT);

        private async Task<T> ExecuteRequest<T>(string url, object body, Method method)
        {
            RestRequest request = new RestRequest(url, method);
            if (body is object)
            {
                request.AddJsonBody(body);
            }

            return (await restClient.ExecuteAsync<T>(request)).Data;
        }
    }
}
