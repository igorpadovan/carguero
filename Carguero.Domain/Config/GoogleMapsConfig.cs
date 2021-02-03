using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Config
{
    public class GoogleMapsConfig
    {
        public string MapsURI { get; set; }
        public string Path { get; set; }
        public string ApiKey { get; set; }
        public string Inputtype { get; set; }
        public string Fields { get; set; }
    }
}
