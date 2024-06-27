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


        // [HttpGet]
        // [Route("/plans")]
        // public async Task<ActionResult> GetPlans()
        // {
        //     var result = await _unitOfWork.Plans.GetAllAsync();
        //     return Ok(result);
        // }
        //
        // [HttpGet]
        // [Route("/plan")]
        // public async Task<ActionResult<Plan>> GetPlan(int id)
        // {
        //     var plan = await _unitOfWork.Plans.GetByIdAsync(id);
        //     if (plan == null)
        //     {
        //         return NotFound("no plan with id");
        //     }
        //
        //     var planDto = _mapper.Map<PlanDto>(plan);
        //
        //     return Ok(planDto);
        // }
        //
        // [HttpPost]
        // [Route("/plan/add")]
        // public async Task<ActionResult<Plan>> AddPlan([FromBody] CUPlanDto planDto)
        // {
        //     var plan = _mapper.Map<Plan>(planDto);
        //     _unitOfWork.Plans.AddAsync(plan);
        //     await _unitOfWork.CompleteAsync();
        //     return CreatedAtAction(nameof(GetPlan), new { id = plan.PlanId }, plan);
        // }
        //

        //     
        //     [HttpGet]
        //     [Route("/type")]
        //     public async Task<ActionResult<Plan>> GetType(int id)
        //     {
        //         var t = await _unitOfWork.Types.GetByIdAsync(id);
        //         if (t == null)
        //         {
        //             return NotFound("no plan with id");
        //         }
        //
        //         return Ok(t);
        //     }
        //     
        //     [HttpGet]
        //     [Route("/type/all")]
        //     public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllType()
        //     {
        //         var types = await _unitOfWork.Types.GetAllAsync();
        //         var typeDtos = _mapper.Map<IEnumerable<TypeDto>>(types);
        //         return Ok(typeDtos);
        //     }
        //     
        //     [HttpPost]
        //     [Route("/type/add")]
        //     public async Task<ActionResult<Type>> AddType([FromBody] CUTypeDto typeDto)
        //     {
        //         var type = _mapper.Map<Type>(typeDto);
        //         _unitOfWork.Types.AddAsync(type);
        //         await _unitOfWork.CompleteAsync();
        //         return CreatedAtAction(nameof(GetType), new { id = type.TypeId }, type);
        //     }
        //
        //     [HttpDelete]
        //     [Route("/type/delete")]
        //     public async Task<ActionResult> DeleteType(int id)
        //     {
        //         var type = await _unitOfWork.Types.GetByIdAsync(id);
        //         if (type == null)
        //         {
        //             return NotFound("nothing found on this id");
        //         }
        //         
        //         //külön szál vagy se?
        //         var result = _unitOfWork.Types.Remove(type);
        //         
        //         await _unitOfWork.CompleteAsync();
        //
        //         return Ok(result);
        //     }
        //
        //     [HttpPost]
        //     [Route("/type/update")]
        //     public async Task<ActionResult<TypeDto>> UpdateType([FromBody] TypeDto typeDto)
        //     {
        //         var type = _mapper.Map<Type>(typeDto);
        //         var updateType = _unitOfWork.Types.Update(type);
        //         await _unitOfWork.CompleteAsync();
        //         var updatedDto = _mapper.Map<TypeDto>(updateType.Entity);
        //         return Ok(updatedDto);
        //     }
        // }
    }
}