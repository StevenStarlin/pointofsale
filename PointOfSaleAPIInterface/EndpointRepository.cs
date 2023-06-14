using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace PointOfSaleAPIInterface
{
    internal class EndpointRepository<T>
    {
        private readonly IConfiguration ApplicationSettings;
        private string EndpointUrl => $"{ApplicationSettings["AppSettings:RemoteURLBase"]}/{typeof(T)}";
        private string appSettingsPath => Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

        public EndpointRepository()
        {
            ApplicationSettings = new ConfigurationBuilder()
                .AddJsonFile(appSettingsPath, optional: false)
                .Build();
        }

        internal RestResponse Create(T postObject)
        {
            var serializedObject = JsonSerializer.Serialize(postObject);

            var client = new RestClient(EndpointUrl);
            var request = new RestRequest()
            {
                Method = Method.Post,
            };

            request.AddParameter("text/plain", serializedObject, ParameterType.RequestBody);

            return client.Execute(request);
        }

        // The id is required explicitly here due to the generic, which I can't access the id of implicitly.
        internal RestResponse Update(int id, T updateObject)
        {
            var serializedObject = JsonSerializer.Serialize(updateObject);

            var client = new RestClient($"{EndpointUrl}/{id}");
            var request = new RestRequest()
            {
                Method = Method.Put,
            };

            request.AddParameter("text/plain", serializedObject, ParameterType.RequestBody);

            return client.Execute(request);
        }

        internal T? Get(int id)
        {
            var client = new RestClient($"{EndpointUrl}/{id}");
            var request = new RestRequest()
            {
                Method = Method.Get,
            };

            var response = client.Execute(request);
            var nullSafeResponse = response?.Content ?? string.Empty;

            return JsonSerializer.Deserialize<T>(nullSafeResponse);
        }

        internal RestResponse Delete(int id)
        {
            var client = new RestClient($"{EndpointUrl}/{id}");
            var request = new RestRequest()
            {
                Method = Method.Delete,
            };

            return client.Execute(request);
        }
    }
}
