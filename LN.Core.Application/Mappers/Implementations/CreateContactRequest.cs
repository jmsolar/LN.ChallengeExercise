using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Contact.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.PhoneNumber.Requests;
using LN.Application.DTOs.State.Requests;
using LN.Application.Mappers.Interfaces;
using LN.Core.Application.DTOs.Address.Responses;
using LN.Core.Application.DTOs.City.Responses;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.DTOs.Country.Responses;
using LN.Core.Application.DTOs.PhoneNumber.Responses;
using LN.Core.Application.DTOs.State.Responses;

namespace LN.Application.Mappers.Implementations
{
    public class CreateContactRequest : IMapContactRequest<NewContactDTO, ContactDTO>
    {
        #region request y response
        public NewContactDTO _requestToMap;
        public ContactDTO _responseToMap;
        #endregion

        private NewPhoneNumberDTO _phoneNumber;
        private NewAddressDTO _address;
        private NewCountryDTO _country;
        private NewStateDTO _state;
        private NewCityDTO _city;

        /// <summary>
        /// Set data to map
        /// </summary>
        /// <param name="request"></param>
        public void AssignRequest(NewContactDTO request)
        {
            _phoneNumber = request.PhoneNumber;
            _address = request.Address;
            _country = _address.Country;
            _state = _address.State;
            _city = _address.City;
        }

        /// <summary>
        /// Maps a request
        /// </summary>
        public void MapRequest()
        {
            PhoneNumberDTO phoneNumber = TranslatePhoneNumberRequest();
            AddressDTO address = TranslateAddressRequest();
            TranslateContactRequest(phoneNumber, address);
        }

        /// <summary>
        /// Return the response mapped
        /// </summary>
        /// <returns></returns>
        public ContactDTO MapResponse() => _responseToMap;

        #region request translators
        private PhoneNumberDTO TranslatePhoneNumberRequest()
        {
            return new PhoneNumberDTO()
            {
                CountryCode = _phoneNumber.CountryCode,
                StateCode = _phoneNumber.StateCode,
                Number = _phoneNumber.Number
            };
        }

        private AddressDTO TranslateAddressRequest()
        {
            CountryDTO country = TranslateCountry();
            StateDTO state = TranslateState();
            CityDTO city = TranslateCity();

            return new AddressDTO()
            {
                Country = country,
                State = state,
                City = city,
                Detail = _address.Detail
            };
        }

        private CountryDTO TranslateCountry()
        {
            return new CountryDTO()
            {
                AlphaCode = _country.AlphaCode,
                Name = _country.Name,
                NumericCode = _country.NumericCode
            };
        }

        private StateDTO TranslateState()
        {
            return new StateDTO()
            {
                Code = _state.Code,
                Name = _state.Name
            };
        }

        private CityDTO TranslateCity()
        {
            return new CityDTO()
            {
                Name = _city.Name,
                ZipCode = _city.ZipCode
            };
        }

        private void TranslateContactRequest(PhoneNumberDTO phoneNumber, AddressDTO address)
        {
            _responseToMap = new ContactDTO()
            {
                Name = _requestToMap.Name,
                Company = _requestToMap.Company,
                Profile = _requestToMap.Profile,
                Image = _requestToMap.Image,
                Email = _requestToMap.Email,
                Birthdate = _requestToMap.Birthdate,
                PhoneNumber = phoneNumber,
                Address = address
            };
        }
        #endregion

        //#region response translators
        //private PhoneNumberResponseDTO TranslatePhoneNumberResponse()
        //{
        //    return new PhoneNumberResponseDTO()
        //    {
        //        CountryCode = _contact.PhoneNumber.CountryCode,
        //        StateCode = _contact.PhoneNumber.StateCode,
        //        Number = _contact.PhoneNumber.Number
        //    };
        //}

        //private AddressResponseDTO TranslateAddressResponse()
        //{
        //    var countryResponse = TranslateCountryResponse();
        //    var stateResponse = TranslateStateResponse();
        //    var cityResponse = TranslateCityResponse();

        //    return new AddressResponseDTO()
        //    {
        //        Country = countryResponse,
        //        State = stateResponse,
        //        City = cityResponse,
        //        Detail = _contact.Address.Detail
        //    };
        //}

        //private CountryResponseDTO TranslateCountryResponse()
        //{
        //    return new CountryResponseDTO()
        //    {
        //        Name = _contact.Address.Country.Name,
        //        NumericCode = _contact.Address.Country.NumericCode,
        //        AlphaCode = _contact.Address.Country.AlphaCode
        //    };
        //}

        //private StateResponseDTO TranslateStateResponse()
        //{
        //    return new StateResponseDTO()
        //    {
        //        Code = _contact.Address.State.Code,
        //        Name = _contact.Address.State.Name
        //    };
        //}

        //private CityResponseDTO TranslateCityResponse()
        //{
        //    return new CityResponseDTO()
        //    {
        //        ZipCode = _contact.Address.City.ZipCode,
        //        Name = _contact.Address.City.Name
        //    };
        //}

        //private ContactResponseDTO TranslateContactResponse(PhoneNumberResponseDTO phoneNumberResponse, AddressResponseDTO addressResponse)
        //{
        //    return new ContactResponseDTO()
        //    {
        //        Name = _contact.Name,
        //        Company = _contact.Company,
        //        Profile = _contact.Profile,
        //        Image = _contact.Image,
        //        Email = _contact.Email,
        //        Birthdate = _contact.Birthdate,
        //        PhoneNumber = phoneNumberResponse,
        //        Address = addressResponse
        //    };
        //}
        //#endregion

    }
}
