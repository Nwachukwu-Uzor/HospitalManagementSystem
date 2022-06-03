using AutoMapper;
using HospitalManagement.Commons.Contracts;
using HospitalManagement.Data;
using HospitalManagement.Data.Contracts;
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
        protected readonly ISmsService _smsService;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, IEmailService emailService, ISmsService smsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountService = accountService;
            _emailService = emailService;
            _smsService = smsService;
        }

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public IAccountService AccountService { get; }
        public IEmailService EmailService { get; }
    }
}
