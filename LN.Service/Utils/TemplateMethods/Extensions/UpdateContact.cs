using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Contact.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.PhoneNumber.Requests;
using LN.Application.DTOs.State.Requests;
using LN.Core.Domain.Entities;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Extensions
{
    public class UpdateContact : ContactBaseTemplate
    {
        private ModifyContactDTO _contactRequestToMap;
        private ModifyPhoneNumberDTO _phoneNumber;
        private ModifyAddressDTO _address;
        private ModifyStateDTO _state;
        private ModifyCityDTO _city;
        private ModifyCountryDTO _country;

        private string query;
        private List<SqlParameter> parameters;

        public override void Setup()
        {
            _contactRequestToMap = _modifyContact;
            _phoneNumber = _contactRequestToMap.PhoneNumber;
            _address = _contactRequestToMap.Address;
            _state = _address.State;
            _country = _address.Country;
            _city = _address.City;

            query = "EXEC ApplicationDB.Contact_Update @Name, @Company, @Profile, @CountryCode, @StateCodePH, @NumberPH, @IsPersonal, @CountryName, @CountryNumCode, @AlphaCode, @StateCode, @StateName, @ZipCode, @CityName, @AddressDetail, @Id";

            // Create parameters
            parameters = new List<SqlParameter>();
            parameters.AddRange(new List<SqlParameter> {
                new SqlParameter { ParameterName = "@Name", Value = !string.IsNullOrEmpty(_modifyContact.Name) ? _modifyContact.Name : SqlString.Null },
                new SqlParameter { ParameterName = "@Company", Value = !string.IsNullOrEmpty(_modifyContact.Company) ? _modifyContact.Company : SqlString.Null },
                new SqlParameter { ParameterName = "@Profile", Value = !string.IsNullOrEmpty(_modifyContact.Profile) ? _modifyContact.Profile : SqlString.Null },
                new SqlParameter { ParameterName = "@CountryCode", Value = !string.IsNullOrEmpty(_phoneNumber.CountryCode) ? _phoneNumber.CountryCode : SqlString.Null },
                new SqlParameter { ParameterName = "@StateCodePH", Value = !string.IsNullOrEmpty(_phoneNumber.StateCode) ? _phoneNumber.StateCode : SqlString.Null },
                new SqlParameter { ParameterName = "@NumberPH", Value = !string.IsNullOrEmpty(_phoneNumber.Number) ? _phoneNumber.Number : SqlString.Null },
                new SqlParameter { ParameterName = "@IsPersonal", Value = _phoneNumber.IsPersonal },
                new SqlParameter { ParameterName = "@CountryName", Value = !string.IsNullOrEmpty(_country.Name) ? _country.Name : SqlString.Null },
                new SqlParameter { ParameterName = "@CountryNumCode", Value = _country.NumericCode != null ? _country.NumericCode : SqlInt32.Null},
                new SqlParameter { ParameterName = "@AlphaCode", Value = !string.IsNullOrEmpty(_country.AlphaCode) ? _country.AlphaCode : SqlString.Null },
                new SqlParameter { ParameterName = "@StateCode", Value = !string.IsNullOrEmpty(_state.Code) ? _state.Code : SqlString.Null },
                new SqlParameter { ParameterName = "@StateName", Value = !string.IsNullOrEmpty(_state.Name) ? _state.Name : SqlString.Null },
                new SqlParameter { ParameterName = "@ZipCode", Value = _city.ZipCode != null ? _city.ZipCode : SqlInt32.Null},
                new SqlParameter { ParameterName = "@CityName", Value = !string.IsNullOrEmpty(_city.Name) ? _city.Name : SqlString.Null },
                new SqlParameter { ParameterName = "@AddressDetail", Value = !string.IsNullOrEmpty(_address.Detail) ? _address.Detail : SqlString.Null },
                new SqlParameter { ParameterName = "@Id", Value = _id }});
        }

        public override async Task CRUDOperation()
        {
            await _contactRepository.Update(query, parameters);
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
