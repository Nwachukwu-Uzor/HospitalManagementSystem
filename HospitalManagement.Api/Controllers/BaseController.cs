using HospitalManagement.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
    }
}
