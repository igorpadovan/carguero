using Carguero.Domain.Entities;
using Carguero.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class GoogleMapsApi: IGoogleMapsApi
    {
        public async Task<GoogleMapsCandidatesAddress> SearchAddress(Address address)
        {
            var restClient = new RestClient("https://maps.googleapis.com/maps/api");
                //input = 79006331 & inputtype = textquery & fields = formatted_address & key = AIzaSyDXWuu3VSPwFfKFKcgYivrtrqBUqcPQCWQ
                var request = new RestRequest("/place/findplacefromtext/json", Method.GET);
            request.AddParameter("input", "", ParameterType.QueryString);
            request.AddParameter("inputtype", "textquery", ParameterType.QueryString);
            request.AddParameter("fields", "formatted_address", ParameterType.QueryString);
            request.AddParameter("key", "", ParameterType.QueryString);

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
