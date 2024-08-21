using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using Backend.Data;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Model.DTO.PlandetailExtended;
using Backend.Services.Authentication.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AllDataController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ITokenExtractor _tokenExtractor;

    public AllDataController(ApplicationDbContext context, ITokenExtractor tokenExtractor)
    {
        _context = context;
        _tokenExtractor = tokenExtractor;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PlanDetailsDto>>> GetAll()
    {
        var query = _context.PlanDetails
                .Include(pd => pd.Plan)
                .ThenInclude(p => p.Type)
                .AsQueryable()
            ;


        var planDetails = await query.Select(pd => new PlanDetailsDto
        {
            DetailId = pd.DetailId,
            SubscriptionDate = pd.SubscriptionDate,
            DateFrom = pd.DateFrom,
            DateTo = pd.DateTo,
            IsCompleted = pd.IsCompleted,
            IsPrivate = pd.IsPrivate,
            PlansDto = new PlansDto
            {
                PlanId = pd.Plan.PlanId,
                Title = pd.Plan.Title,
                City = pd.Plan.City,
                TypeDescription = pd.Plan.Type.Description,
                Description = pd.Plan.Description,
                CreatedAt = pd.Plan.CreatedAt,
                Private = pd.Plan.IsPrivate
            }
        }).ToListAsync();
        return Ok(planDetails);

    }
    
    [HttpGet("allSubscribers"), Authorize(Roles = ("Admin, User"))]
    public async Task<ActionResult<IEnumerable<PlanDetailsDto>>> GetAllSubsribers()
    {
        var query = _context.Subscribers
                .Include(s => s.PlanDetail)
                .ThenInclude(p => p.Plan)
                .Include(s=>s.User)
                .AsQueryable()
            ;


        var subscribers = await query.Select(pd => new SubscribersDto
        {
            SubscriberId = pd.SubscriberId,
            PlanDetailsDto = new PlanDetailsDto{
            DetailId = pd.PlanDetail.DetailId,
            SubscriptionDate = pd.PlanDetail.SubscriptionDate,
            DateFrom = pd.PlanDetail.DateFrom,
            DateTo = pd.PlanDetail.DateTo,
            IsCompleted = pd.PlanDetail.IsCompleted,
            IsPrivate = pd.PlanDetail.IsPrivate,
            PlansDto = new PlansDto
            {
                PlanId = pd.PlanDetail.Plan.PlanId,
                Title = pd.PlanDetail.Plan.Title,
                City = pd.PlanDetail.Plan.City,
                TypeDescription = pd.PlanDetail.Plan.Type.Description,
                Description = pd.PlanDetail.Plan.Description,
                CreatedAt = pd.PlanDetail.Plan.CreatedAt,
                Private = pd.PlanDetail.Plan.IsPrivate
            }},
            UserDto = new UserDto
            {
                Username = pd.User.Username,
                UserId = pd.User.UserId,
                Email = pd.User.Email,
                Premium = pd.User.Premium,
                BirthDate = pd.User.BirthDate
            }
            
        }).ToListAsync();
        return Ok(subscribers);

    }

    [HttpGet("MySubscriptions"), Authorize(Roles = ("Admin, User"))]
    public async Task<ActionResult<IEnumerable<PlanDetail>>> MySubscribedPlans()
    {
        var token = HttpContext.Request.Cookies["jwt"];
       
        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized();
        }
        
        var email = _tokenExtractor.GetEmailFromToken(token);
        
        if (email == null)
        {
            return Unauthorized();
        }
        
        
        var subscriptions = await _context.Subscribers
            .Include(s => s.User)
            .Include(s => s.PlanDetail)
            .ThenInclude(pd=>pd.Plan)
            .ThenInclude(p=>p.Type)
            .Where(c => c.User.Email == email)
            .Select(t => t.PlanDetail).ToListAsync();
        
        
        return Ok(subscriptions);
    }
}
    