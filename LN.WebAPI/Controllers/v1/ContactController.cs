using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
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
        public async Task<Response<ContactDTO>> Get(Guid id)
        {
            return await _contactService.GetContactById(id);
        }

        // POST api/<ContactController>
        [HttpPost] 
        public async Task<Response<ContactDTO>> Post([FromBody] NewContactDTO request)
        {
            return await _contactService.CreateContact(request);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<Response<bool>> Put(Guid id, [FromBody] ModifyContactDTO request)
        {
            return await _contactService.UpdateContact(id, request);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<Response<bool>> Delete(Guid id)
        {
            return await _contactService.DeleteContact(id); ;
        }
    }
}
