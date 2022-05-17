using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IAccountService _accountService;
        protected readonly IEmailService _emailService;
        public BaseController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountService = accountService;
            _emailService = emailService;
        }
    }
}
