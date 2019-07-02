using RestSharp;

namespace Aubit.Judge
{
    public class SwaggerClient
    {
        private RestClient restClient;

        public SwaggerClient(string url)
        {
            restClient = new RestClient(url);
        }

        public string GetSwaggerDefinition(string path)
        {
            var request = new RestRequest(path);
            var response = restClient.Execute(request);
            return response.Content;
        }
    }
}
