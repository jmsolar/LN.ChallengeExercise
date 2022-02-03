using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LN.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMemoryCache _memoryCache;

        // Properties to detail contact
        private readonly string _detailKey = "detailKey";
        private readonly MemoryCacheEntryOptions _detailCacheOptions = new MemoryCacheEntryOptions()
            .SetSize(1)
            .SetSlidingExpiration(TimeSpan.FromMinutes(2)) // Fuerza a caducar un elemento en cache
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); // Sin importar el tiempo en cache, el almacenamiento caducara en

        public ContactController(IContactService contactService, IMemoryCache memoryCache)
        {
            _contactService = contactService;
            _memoryCache = memoryCache;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == null) return BadRequest();

            Response<ContactDTO> response;
            var detailKey = string.Concat(_detailKey, "_", id);

            // Valido si existe el dato en cache
            if (_memoryCache.TryGetValue(detailKey, out response)) return Ok(response);

            response = await _contactService.GetContactById(id);
            if (response.Success && !response.Errors.Any()) _memoryCache.Set(detailKey, response, _detailCacheOptions);

            return Ok(response);
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
