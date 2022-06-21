using HospitalManagementApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
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
