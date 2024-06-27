using AutoMapper;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Type = Backend.Model.Type;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {

        private readonly ILogger<ApplicationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ApplicationController(ILogger<ApplicationController> logger, IConfiguration configuration,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(_configuration["ApiKey"]);
        }

        [HttpGet]
        [Route("/plans")]
        public async Task<ActionResult> GetPlans()
        {
            var result = await _unitOfWork.Plans.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("/plan")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _unitOfWork.Plans.GetByIdAsync(id);
            if (plan == null)
            {
                return NotFound("no plan with id");
            }

            var planDto = _mapper.Map<PlanDto>(plan);

            return Ok(planDto);
        }

        [HttpPost]
        [Route("/plan/add")]
        public async Task<ActionResult<Plan>> AddPlan([FromBody] CUPlanDto plan)
        {
            
            _unitOfWork.Plans.AddAsync(plan);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetPlan), new { id = plan.PlanId }, plan);
        }
        
        [HttpPost]
        [Route("/type/add")]
        public async Task<ActionResult<Type>> AddType([FromBody] CUTypeDto typeDto)
        {
            var type = _mapper.Map<Type>(typeDto);
            _unitOfWork.Types.AddAsync(type);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetType), new { id = type.TypeId }, type);
        }
        
        [HttpGet]
        [Route("/type")]
        public async Task<ActionResult<Plan>> GetType(int id)
        {
            var t = await _unitOfWork.Types.GetByIdAsync(id);
            if (t == null)
            {
                return NotFound("no plan with id");
            }

            return Ok(t);
        }

        
    }
}