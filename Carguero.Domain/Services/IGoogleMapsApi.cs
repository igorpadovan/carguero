using Carguero.Domain.Entities;
using Carguero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IGoogleMapsApi
    {
        Task<GoogleMapsCandidatesAddress> SearchAddress(string address);
    }
}
