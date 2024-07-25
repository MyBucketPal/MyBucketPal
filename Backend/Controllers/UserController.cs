using AutoMapper;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using User = Backend.Model.User;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(ILogger<TypeController> logger, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetType(int id)
        {
            var t = await _unitOfWork.Users.GetByIdAsync(id);
            if (t == null)
            {
                return NotFound("no plan with id");
            }

            return Ok(t);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllType()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<User>> AddUser([FromBody] CUUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetType), new { id = user.UserId }, user);
        }

        [HttpDelete]
        [Route("delete{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("nothing found on this id");
            }
            _unitOfWork.Types.Remove(id);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpPost]
        [Route("update{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var updateUser = _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
            var updatedDto = _mapper.Map<UserDto>(updateUser.Entity);
            return Ok(updatedDto);
        }



    }

}
