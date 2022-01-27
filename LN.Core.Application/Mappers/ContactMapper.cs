using LN.Core.Application.DTOs.Address;
using LN.Core.Application.DTOs.City;
using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.DTOs.Country;
using LN.Core.Application.DTOs.PhoneNumber;
using LN.Core.Application.DTOs.State;
using LN.Core.Domain.Entities;

namespace LN.Application.Mappers
{
    public static class ContactMapper
    {
        private static ContactRequestDTO _contactRequest;
        private static Contact _contact;

        /// <summary>
        /// Maps request to contact
        /// </summary>
        /// <param name="contactReqDTO"></param>
        /// <returns></returns>
        public static Contact ToContact(ContactRequestDTO contactReqDTO)
        {
            _contactRequest = contactReqDTO;

            PhoneNumber phoneNumber = TranslatePhoneNumberRequest();
            Address address = TranslateAddressRequest();
            Contact contact = TranslateContactRequest(phoneNumber, address);

            return contact;
        }

        /// <summary>
        /// Maps contact to reponse contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static ContactResponseDTO ToContactResponse(Contact contact)
        {
            _contact = contact;

            PhoneNumberResponseDTO phoneNumberResponse = TranslatePhoneNumberResponse();
            AddressResponseDTO addressResponse = TranslateAddressResponse();
            ContactResponseDTO contactResponse = TranslateContactResponse(phoneNumberResponse, addressResponse);

            return contactResponse;
        }

        #region request translators
        private static PhoneNumber TranslatePhoneNumberRequest()
        {
            return new PhoneNumber()
            {
                CountryCode = _contactRequest.PhoneCountryCode,
                StateCode = _contactRequest.PhoneStateCode,
                Number = _contactRequest.PhoneNumber
            };
        }

        private static Contact TranslateContactRequest(PhoneNumber phoneNumber, Address address)
        {
            return new Contact()
            {
                Name = _contactRequest.Name,
                Company = _contactRequest.Company,
                Profile = _contactRequest.Profile,
                Image = _contactRequest.Image,
                Email = _contactRequest.Email,
                Birthdate = _contactRequest.Birthdate,
                PhoneNumber = phoneNumber,
                Address = address
            };
        }

        private static Address TranslateAddressRequest()
        {
            Country country = TranslateCountry();
            State state = TranslateState();
            City city = TranslateCity();

            return new Address()
            {
                Country = country,
                State = state,
                City = city,
                Detail = _contactRequest.CityDetail
            };
        }

        private static Country TranslateCountry()
        {
            return new Country() { 
                AlphaCode = _contactRequest.CountryAlphaCode,
                Name = _contactRequest.CountryName,
                NumericCode = _contactRequest.CountryNumericCode
            };
        }

        private static State TranslateState()
        {
            return new State() { 
                Code = _contactRequest.StateCode,
                Name = _contactRequest.StateName
            };
        }

        private static City TranslateCity()
        {
            return new City() { 
                Name = _contactRequest.CityName,
                ZipCode = _contactRequest.CityZipCode
            };
        }
        #endregion

        #region response translators
        private static PhoneNumberResponseDTO TranslatePhoneNumberResponse()
        {
            return new PhoneNumberResponseDTO() {
                CountryCode = _contact.PhoneNumber.CountryCode,
                StateCode = _contact.PhoneNumber.StateCode,
                Number = _contact.PhoneNumber.Number
            };
        }

        private static AddressResponseDTO TranslateAddressResponse()
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

        private static CountryResponseDTO TranslateCountryResponse()
        {
            return new CountryResponseDTO() {
                Name = _contact.Address.Country.Name,
                NumericCode = _contact.Address.Country.NumericCode,
                AlphaCode = _contact.Address.Country.AlphaCode
            };
        }

        private static StateResponseDTO TranslateStateResponse()
        {
            return new StateResponseDTO() { 
                Code = _contact.Address.State.Code,
                Name = _contact.Address.State.Name
            };
        }

        private static CityResponseDTO TranslateCityResponse()
        {
            return new CityResponseDTO() { 
                ZipCode = _contact.Address.City.ZipCode,
                Name = _contact.Address.City.Name
            };
        }

        private static ContactResponseDTO TranslateContactResponse(PhoneNumberResponseDTO phoneNumberResponse, AddressResponseDTO addressResponse)
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
