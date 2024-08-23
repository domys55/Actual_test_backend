using DataModels.DTOs;
using InterfaceCollection.service;
using Microsoft.AspNetCore.Mvc;
using Model_lib;

namespace Actual_test_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService service)
        {
            _contactService = service;
        }

        [HttpGet]
        public ActionResult<APIResponse<IEnumerable<ContactDTO>>> GetTestItems()
        {
            var items = _contactService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public ActionResult<APIResponse<ContactDTO>> AddTestItem(int id)
        {
            var response = _contactService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<APIResponse<ContactDTO>> AddTestItem(ContactDTO entity)
        {
            var response = _contactService.Add(entity);
            return Ok(response);
        }
    }
}
