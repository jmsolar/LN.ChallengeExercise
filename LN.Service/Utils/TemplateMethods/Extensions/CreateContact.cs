using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Contact.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.PhoneNumber.Requests;
using LN.Application.DTOs.State.Requests;
using LN.Core.Domain.Entities;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Extensions
{
    public class CreateContact : ContactBaseTemplate
    {
        private NewContactDTO _contactRequestToMap;
        private NewPhoneNumberDTO _phoneNumber;
        private NewAddressDTO _address;
        private NewCityDTO _city;
        private NewCountryDTO _country;
        private NewStateDTO _state;

        public override void Setup()
        {
            _contactRequestToMap = _newContact;
            _phoneNumber = _contactRequestToMap.PhoneNumber;
            _address = _contactRequestToMap.Address;
            _city = _address.City;
            _state = _address.State;
            _country = _address.Country;
        }

        public override async Task CRUDOperation() {
            await _contactRepository.Add(_requestMapped);
        }

        public override void MapRequest()
        {
            PhoneNumber phoneNumber = TranslatePhoneNumberRequest();
            Address address = TranslateAddressRequest();
            TranslateContactRequest(phoneNumber, address);
        }

        #region request translators
        private PhoneNumber TranslatePhoneNumberRequest()
        {
            return new PhoneNumber()
            {
                CountryCode = _phoneNumber.CountryCode,
                StateCode = _phoneNumber.StateCode,
                Number = _phoneNumber.Number,
                IsPersonal = _phoneNumber.IsPersonal
            };
        }

        private Address TranslateAddressRequest()
        {
            Country country = TranslateCountry();
            State state = TranslateState();
            City city = TranslateCity();

            return new Address()
            {
                Country = country,
                State = state,
                City = city,
                Detail = _address.Detail
            };
        }

        private Country TranslateCountry()
        {
            return new Country()
            {
                AlphaCode = _country.AlphaCode,
                Name = _country.Name,
                NumericCode = _country.NumericCode
            };
        }

        private State TranslateState()
        {
            return new State()
            {
                Code = _state.Code,
                Name = _state.Name
            };
        }

        private City TranslateCity()
        {
            return new City()
            {
                Name = _city.Name,
                ZipCode = _city.ZipCode
            };
        }

        private void TranslateContactRequest(PhoneNumber phoneNumber, Address address)
        {
            _requestMapped = new Contact()
            {
                Name = _contactRequestToMap.Name,
                Company = _contactRequestToMap.Company,
                Profile = _contactRequestToMap.Profile,
                Image = _contactRequestToMap.Image,
                Email = _contactRequestToMap.Email,
                Birthdate = _contactRequestToMap.Birthdate,
                PhoneNumber = phoneNumber,
                Address = address
            };
        }
        #endregion
    }
}
