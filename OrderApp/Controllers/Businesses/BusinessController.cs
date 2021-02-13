using Microsoft.AspNetCore.Mvc;
using OrderApp.Data.Entities;
using OrderApp.Services.Businesses;
using System.Threading.Tasks;

namespace OrderApp.Controllers.Businesses
{
    [Route("businesses")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _service;

        public BusinessController(IBusinessService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusiness([FromBody]Business business) 
        {
            var saved = await _service.Save(business);
            if (saved.HasValue)
                return Created("", saved.ValueOr(() => null));
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses()
        {
            var businesses = await _service.GetAll();
            if (businesses != null && businesses.Count > 0) 
            {
                return Ok(businesses);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBusinessByID([FromRoute]string id)
        {
            var request = new Business
            {
                BusinessID = id
            };
            var business = await _service.Get(request);
            if (business.HasValue )
            {
                return Ok(business.ValueOr( () => null ));
            }
            return NotFound();
        }
    }
}
