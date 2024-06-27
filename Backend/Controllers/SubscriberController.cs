using AutoMapper;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Subscriber = Backend.Model.Subscriber;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriberController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubscriberController(ILogger<TypeController> logger, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/subscriber/{id}")]
        public async Task<ActionResult<Subscriber>> GetType(int id)
        {
            var t = await _unitOfWork.Subscribers.GetByIdAsync(id);
            if (t == null)
            {
                return NotFound("no plan with id");
            }

            return Ok(t);
        }

        [HttpGet]
        [Route("/subscriber/all")]
        public async Task<ActionResult<IEnumerable<SubscriberDto>>> GetAllType()
        {
            var subscribers = await _unitOfWork.Subscribers.GetAllAsync();
            var subscriberDtos = _mapper.Map<IEnumerable<SubscriberDto>>(subscribers);
            return Ok(subscriberDtos);
        }

        [HttpPost]
        [Route("/subscriber/add")]
        public async Task<ActionResult<Subscriber>> AddSubscriber([FromBody] CUSubscriberDto subscriberDto)
        {
            var subscriber = _mapper.Map<Subscriber>(subscriberDto);
            await _unitOfWork.Subscribers.AddAsync(subscriber);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetType), new { id = subscriber.SubscriberId }, subscriber);
        }

        [HttpDelete]
        [Route("/subscriber/delete{id}")]
        public async Task<ActionResult> DeleteSubscriber(int id)
        {
            var subscriber = await _unitOfWork.Subscribers.GetByIdAsync(id);
            if (subscriber == null)
            {
                return NotFound("nothing found on this id");
            }

            _unitOfWork.Types.Remove(id);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost]
        [Route("/subscriber/update{id}")]
        public async Task<ActionResult<SubscriberDto>> UpdateSubscriber([FromBody] SubscriberDto subscriberDto)
        {
            var subscriber = _mapper.Map<Subscriber>(subscriberDto);
            var updateSubscriber = _unitOfWork.Subscribers.Update(subscriber);
            await _unitOfWork.CompleteAsync();
            var updatedDto = _mapper.Map<SubscriberDto>(updateSubscriber.Entity);
            return Ok(updatedDto);
        }
    }
}
