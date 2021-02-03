using Carguero.Domain.Config;
using Carguero.Domain.Entities;
using Carguero.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class GoogleMapsApi: IGoogleMapsApi
    {
        private readonly GoogleMapsConfig _config;
        public GoogleMapsApi(IOptions<GoogleMapsConfig> config)
        {
            _config = config.Value;
        }
        public async Task<GoogleMapsCandidatesAddress> SearchAddress(string  address)
        {
            var restClient = new RestClient(_config.MapsURI);
            var request = new RestRequest(_config.Path, Method.GET);

            request.AddParameter("input", address, ParameterType.QueryString);
            request.AddParameter("inputtype", _config.Inputtype, ParameterType.QueryString);
            request.AddParameter("fields", _config.Fields, ParameterType.QueryString);
            request.AddParameter("key", _config.ApiKey, ParameterType.QueryString);

            var response = await restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var googleMapsAddress = JsonConvert.DeserializeObject<GoogleMapsCandidatesAddress>(response.Content);
                return googleMapsAddress;
            }

            return null;
        }

        
    }
}
