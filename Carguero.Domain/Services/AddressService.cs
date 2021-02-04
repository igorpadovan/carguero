using Carguero.Domain.Entities;
using Carguero.Domain.Repositories;
using Carguero.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRespository;
        private IUserRepository _userRepository;
        private IGoogleMapsApi _googleMapsApi;
        private string Abbreviated;
        public AddressService(
            IAddressRepository addressRespository,
            IUserRepository userRepository,
            IGoogleMapsApi googleMapsApi)
        {
            _addressRespository = addressRespository;
            _userRepository = userRepository;
            _googleMapsApi = googleMapsApi;
        }

        public async Task<bool> RegisterAddress(Address address)
        {
            var user =  _userRepository.GetById(address.UserId);
            if (user == null)
                return false;
            address.SetUser(user);

            bool addressFromBrazil = await IsBrazilianAddress(address);
            if (!addressFromBrazil)
                return false;

            await _addressRespository.SaveAsync(address);
            return (address.Id > 0);
        }

        public async Task<bool> IsBrazilianAddress(Address address)
        {
            string formatedAddress = FormatAddressForMapsApi(address);
            GoogleMapsCandidatesAddress googleMapsAddress = await _googleMapsApi.SearchAddress(formatedAddress);

            if (googleMapsAddress.GoogleMapsCandidates.Count == 0)
                return false;
            if (googleMapsAddress.GoogleMapsCandidates.Count > 1)
                return false;
            return true;
        }

        public string FormatAddressForMapsApi(Address address)
        {
            return $"{address.District}, {address.City} - {AbbreviatedState(address.State)}, {address.ZipCode}, Brasil";
        }        

        public string AbbreviatedState(string state)
        {
            switch (state.ToUpper())
            {
                case "ACRE": Abbreviated = "AC"; break;
                case "ALAGOAS": Abbreviated = "AL"; break;
                case "AMAZONAS": Abbreviated = "AM"; break;
                case "AMAPÁ": Abbreviated = "AP"; break;
                case "BAHIA": Abbreviated = "BA"; break;
                case "CEARÁ": Abbreviated = "CE"; break;
                case "DISTRITO FEDERAL": Abbreviated = "DF"; break;
                case "ESPÍRITO SANTO": Abbreviated = "ES"; break;
                case "GOIÁS": Abbreviated = "GO"; break;
                case "MARANHÃO": Abbreviated = "MA"; break;
                case "MINAS GERAIS": Abbreviated = "MG"; break;
                case "MATO GROSSO DO SUL": Abbreviated = "MS"; break;
                case "MATO GROSSO": Abbreviated = "MT"; break;
                case "PARÁ": Abbreviated = "PA"; break;
                case "PARAÍBA": Abbreviated = "PB"; break;
                case "PERNAMBUCO": Abbreviated = "PE"; break;
                case "PIAUÍ": Abbreviated = "PI"; break;
                case "PARANÁ": Abbreviated = "PR"; break;
                case "RIO DE JANEIRO": Abbreviated = "RJ"; break;
                case "RIO GRANDE DO NORTE": Abbreviated = "RN"; break;
                case "RONDÔNIA": Abbreviated = "RO"; break;
                case "RORAIMA": Abbreviated = "RR"; break;
                case "RIO GRANDE DO SUL": Abbreviated = "RS"; break;
                case "SANTA CATARINA": Abbreviated = "SC"; break;
                case "SERGIPE": Abbreviated = "SE"; break;
                case "SÃO PAULO": Abbreviated = "SP"; break;
                case "TOCANTÍNS": Abbreviated = "TO"; break;
            }
            return Abbreviated;
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            var registeredAddress = _addressRespository.GetById(address.Id);
            if (registeredAddress == null)
                return false;

            _addressRespository.Update(address);
            return true;

        }

        public List<Address> GetAddressesByUsername(string username)
        {
            var addresses = _addressRespository.GetAddressesByUsername(username);
            return addresses;
        }

        public int Delete(int id)
        {
            return _addressRespository.Delete(id);
        }
    }
}

