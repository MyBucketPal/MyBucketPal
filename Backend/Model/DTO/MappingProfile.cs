using AutoMapper;

namespace Backend.Model.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Plan, PlanDto>();
        CreateMap<CUPlanDto, Plan>();
        
        CreateMap<PlanDetail, PlanDetialDto>();
        CreateMap<CUPlanDetailDto, PlanDetail>();
        
        CreateMap<Subscriber, SubsribersDto>();
        CreateMap<CUSubscribersDto, Subscriber>();
        
        CreateMap<Type, TypeDto>();
        CreateMap<CUTypeDto, Type>();
        
        CreateMap<User, UserDto>();
        CreateMap<CUUserDto, User>();
        
        
        
    }
}
