using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Entities
{
    [NotMapped]
    public class GoogleMapsCandidatesAddress
    {
        [JsonProperty(PropertyName = "candidates")]
        List<GoogleMapsCandidates> GoogleMapsCandidates;
    }   

}
