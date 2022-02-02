using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Contact.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.PhoneNumber.Requests;
using LN.Application.DTOs.State.Requests;
using LN.Application.NewFolder.Interfaces;
using LN.Core.Application.DTOs.Contact.Responses;

namespace LN.Application.NewFolder.Implementations
{
    public class CreateContactRequest : IMapContactRequest<NewContactDTO, ContactResponseDTO>
    {
        public NewContactDTO _requestToMap;
        public ContactResponseDTO _responseToMap;

        public void AssignRequest(NewContactDTO request) => _requestToMap = request;

        public void MapRequest()
        {
            NewPhoneNumberDTO phoneNumber = TranslatePhoneNumberRequest();
            NewAddressDTO address = TranslateAddressRequest();
            TranslateContactRequest(phoneNumber, address);
        }

        public ContactResponseDTO MapResponse() => _responseToMap;

        #region request translators
        private NewPhoneNumberDTO TranslatePhoneNumberRequest()
        {
            return new NewPhoneNumberDTO()
            {
                CountryCode = _requestToMap.PhoneNumber.CountryCode,
                StateCode = _requestToMap.PhoneNumber.StateCode,
                Number = _requestToMap.PhoneNumber.Number
            };
        }

        private NewAddressDTO TranslateAddressRequest()
        {
            NewCountryDTO country = TranslateCountry();
            NewStateDTO state = TranslateState();
            NewCityDTO city = TranslateCity();

            return new NewAddressDTO()
            {
                Country = country,
                State = state,
                City = city,
                Detail = _requestToMap.D
            };
        }

        private NewCountryDTO TranslateCountry()
        {
            return new NewCountryDTO()
            {
                AlphaCode = _contactRequest.CountryAlphaCode,
                Name = _contactRequest.CountryName,
                NumericCode = _contactRequest.CountryNumericCode
            };
        }

        private NewStateDTO TranslateState()
        {
            return new NewStateDTO()
            {
                Code = _contactRequest.StateCode,
                Name = _contactRequest.StateName
            };
        }

        private NewCityDTO TranslateCity()
        {
            return new City()
            {
                Name = _contactRequest.CityName,
                ZipCode = _contactRequest.CityZipCode
            };
        }

        private void TranslateContactRequest(NewPhoneNumberDTO phoneNumber, NewAddressDTO address)
        {
            _responseToMap = new ContactResponseDTO()
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

        #region response translators
        private PhoneNumberResponseDTO TranslatePhoneNumberResponse()
        {
            return new PhoneNumberResponseDTO()
            {
                CountryCode = _contact.PhoneNumber.CountryCode,
                StateCode = _contact.PhoneNumber.StateCode,
                Number = _contact.PhoneNumber.Number
            };
        }

        private AddressResponseDTO TranslateAddressResponse()
        {
            var countryResponse = TranslateCountryResponse();
            var stateResponse = TranslateStateResponse();
            var cityResponse = TranslateCityResponse();

            return new AddressResponseDTO()
            {
                Country = countryResponse,
                State = stateResponse,
                City = cityResponse,
                Detail = _contact.Address.Detail
            };
        }

        private CountryResponseDTO TranslateCountryResponse()
        {
            return new CountryResponseDTO()
            {
                Name = _contact.Address.Country.Name,
                NumericCode = _contact.Address.Country.NumericCode,
                AlphaCode = _contact.Address.Country.AlphaCode
            };
        }

        private StateResponseDTO TranslateStateResponse()
        {
            return new StateResponseDTO()
            {
                Code = _contact.Address.State.Code,
                Name = _contact.Address.State.Name
            };
        }

        private CityResponseDTO TranslateCityResponse()
        {
            return new CityResponseDTO()
            {
                ZipCode = _contact.Address.City.ZipCode,
                Name = _contact.Address.City.Name
            };
        }

        private ContactResponseDTO TranslateContactResponse(PhoneNumberResponseDTO phoneNumberResponse, AddressResponseDTO addressResponse)
        {
            return new ContactResponseDTO()
            {
                Name = _contact.Name,
                Company = _contact.Company,
                Profile = _contact.Profile,
                Image = _contact.Image,
                Email = _contact.Email,
                Birthdate = _contact.Birthdate,
                PhoneNumber = phoneNumberResponse,
                Address = addressResponse
            };
        }
        #endregion
    }
}
