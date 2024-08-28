using DataModels.DTOs;
using InterfaceCollection.service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model_lib;

namespace Actual_test_backend.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService service)
        {
            _contactService = service;
        }

        [HttpGet]
        public ActionResult<APIResponse<IEnumerable<ContactDTO>>> GetAllContacts()
        {
            var items = _contactService.GetAll();
            return Ok(items);
        }

        [Route("getpage")]
        [HttpPost]
        public ActionResult<APIResponse<IEnumerable<ContactDTO>>> GetAllContactsPaged(PagingDTO dto)
        {
            var items = _contactService.GetAllPaged(dto);
            return Ok(items);
        }

        [Route("getpageTable")]
        [HttpPost]
        public ActionResult<APIResponse<IEnumerable<ContactDTO>>> GetAllContactsPagedTable(PagingDTO dto)
        {
            var items = _contactService.GetAllPagedTable(dto);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public ActionResult<APIResponse<ContactDTO>> GetContactById(int id)
        {
            var response = _contactService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<APIResponse<ContactDTO>> AddContact(ContactDTO entity)
        {
            var response = _contactService.Add(entity);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<APIResponse<ContactDTO>> DeleteContact(int id)
        {
            var response = _contactService.Delete(id);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<APIResponse<ContactDTO>> EditTestItem(ContactDTO entity)
        {
            var response = _contactService.Edit(entity);
            return Ok(response);
        }
    }
}
