using AutoMapper;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using PlanDetail = Backend.Model.PlanDetail;


namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanDetailController : ControllerBase
    {
        private readonly ILogger<PlanController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanDetailController(ILogger<PlanController> logger, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/plandetail/{id}")]
        public async Task<ActionResult<PlanDetail>> GetType(int id)
        {
            var t = await _unitOfWork.PlanDetails.GetByIdAsync(id);
            if (t == null)
            {
                return NotFound("no plan with id");
            }

            return Ok(t);
        }

        [HttpGet]
        [Route("/plandetail/all")]
        public async Task<ActionResult<IEnumerable<PlanDetailDto>>> GetAllType()
        {
            var planDetails = await _unitOfWork.Types.GetAllAsync();
            var planDetailDtos = _mapper.Map<IEnumerable<PlanDetailDto>>(planDetails);
            return Ok(planDetailDtos);
        }

        [HttpPost]
        [Route("/planDetail/add")]
        public async Task<ActionResult<PlanDetail>> AddPlanDetail([FromBody] CUPlanDetailDto planDetailDto)
        {
            var planDetail = _mapper.Map<PlanDetail>(planDetailDto);
            await _unitOfWork.PlanDetails.AddAsync(planDetail);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetType), new { id = planDetail.DetailId }, planDetail);
        }

        [HttpDelete]
        [Route("/planDetail/delete{id}")]
        public async Task<ActionResult> DeletePlanDetail(int id)
        {
            var planDetail = await _unitOfWork.PlanDetails.GetByIdAsync(id);
            if (planDetail == null)
            {
                return NotFound("nothing found on this id");
            }

            //külön szál vagy se?
            var result = _unitOfWork.PlanDetails.Remove(planDetail);

            await _unitOfWork.CompleteAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("/planDetail/update{id}")]
        public async Task<ActionResult<PlanDetailDto>> UpdatePlanDetail([FromBody] PlanDetailDto planDetailDto)
        {
            var planDetail = _mapper.Map<PlanDetail>(planDetailDto);
            var updatePlanDetail = _unitOfWork.PlanDetails.Update(planDetail);
            await _unitOfWork.CompleteAsync();
            var updatedDto = _mapper.Map<PlanDetailDto>(updatePlanDetail.Entity);
            return Ok(updatedDto);
        }
    }
}
