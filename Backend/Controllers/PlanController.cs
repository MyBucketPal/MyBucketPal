using AutoMapper;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Plan = Backend.Model.Plan;


namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly ILogger<PlanController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanController(ILogger<PlanController> logger, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/plan/{id}")]
        public async Task<ActionResult<Plan>> GetType(int id)
        {
            var t = await _unitOfWork.Plans.GetByIdAsync(id);
            if (t == null)
            {
                return NotFound("no plan with id");
            }

            return Ok(t);
        }

        [HttpGet]
        [Route("/plan/all")]
        public async Task<ActionResult<IEnumerable<PlanDto>>> GetAllType()
        {
            var plans = await _unitOfWork.Plans.GetAllAsync();
            var planDtos = _mapper.Map<IEnumerable<PlanDto>>(plans);
            return Ok(planDtos);
        }

        [HttpPost]
        [Route("/plan/add")]
        public async Task<ActionResult<Plan>> AddPlan([FromBody] CUPlanDto planDto)
        {
            var plan = _mapper.Map<Plan>(planDto);
            await _unitOfWork.Plans.AddAsync(plan);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetType), new { id = plan.PlanId }, plan);
        }

        [HttpDelete]
        [Route("/plan/delete{id}")]
        public async Task<ActionResult> DeletePlan(int id)
        {
            var plan = await _unitOfWork.Plans.GetByIdAsync(id);
            if (plan == null)
            {
                return NotFound("nothing found on this id");
            }

            
            _unitOfWork.Types.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost]
        [Route("/plan/update{id}")]
        public async Task<ActionResult<PlanDto>> UpdatePlan([FromBody] PlanDto planDto)
        {
            var plan = _mapper.Map<Plan>(planDto);
            var updatePlan = _unitOfWork.Plans.Update(plan);
            await _unitOfWork.CompleteAsync();
            var updatedDto = _mapper.Map<PlanDto>(updatePlan.Entity);
            return Ok(updatedDto);
        }
    }
}
