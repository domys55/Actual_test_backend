using DataModels.DTOs;
using InterfaceCollection.service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model_lib;
using Service;

namespace Actual_test_backend.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("[controller]")]
    public class ContactAggregateController : ControllerBase
    {
        private readonly IContactAggreagateService _contactService;

        public ContactAggregateController(IContactAggreagateService service)
        {
            _contactService = service;
        }

        [HttpPost]
        public ActionResult<APIResponse<ContactAggregateDTO>> AddContact(ContactAggregateDTO entity)
        {
            var response = _contactService.Add(entity);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<APIResponse<ContactAggregateDTO>> GetContactById(int id)
        {
            var response = _contactService.GetById(id);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<APIResponse<ContactDTO>> DeleteContact(int id)
        {
            var response = _contactService.Delete(id);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<APIResponse<ContactDTO>> EditContact(ContactAggregateDTO entity)
        {
            var response = _contactService.Edit(entity);
            return Ok(response);
        }
    }
}
