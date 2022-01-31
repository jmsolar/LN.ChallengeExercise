using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.Wrappers;
using LN.Service.Implementations;
using LN.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LN.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<Response<ContactResponseDTO>> Get(Guid id)
        {
            var response = await _contactService.GetContactById(id);

            return response;
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<Response<ContactResponseDTO>> Post([FromBody] ContactRequestDTO request)
        {
            var response = await _contactService.CreateContact(request);

            return response;
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<Response<bool>> Put(Guid id, [FromBody] ContactRequestDTO request)
        {
            var response = await _contactService.UpdateContact(id, request);

            return response;
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<Response<bool>> Delete(Guid id)
        {
            var response = await _contactService.DeleteContact(id);

            return response;
        }
    }
}
