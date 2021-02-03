using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Entities
{
    public class GoogleMapsCandidates
    {
        [JsonProperty(PropertyName = "formatted_address")]
        string FormattedAddress;
    }
}
