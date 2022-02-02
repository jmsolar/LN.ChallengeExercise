using LN.Application.DTOs.Contact.Requests;
using LN.Core.Domain.Entities;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.ExtensionsMethod
{
    public class UpdateContact : ContactBaseTemplate
    {
        private ModifyContactDTO _contactRequestToMap;

        public override void Setup()
        {
            _contactRequestToMap = _modifyContact;
        }

        public override async Task CRUDOperation()
        {
            await _contactRepository.Update(_requestMapped);
        }

        public override void MapRequestBase()
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
                Number = _phoneNumber.Number
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
                PhoneNumber = phoneNumber,
                Address = address
            };
        }
        #endregion
    }
}
