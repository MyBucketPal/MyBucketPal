using AutoMapper;

namespace Backend.Model.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Plan, PlanDto>();
        CreateMap<PlanDto, Plan>();
        CreateMap<CUPlanDto, Plan>();
        
        CreateMap<PlanDetail, PlanDetailDto>();
        CreateMap<PlanDetailDto, PlanDetail>();
        CreateMap<CUPlanDetailDto, PlanDetail>();
        
        CreateMap<Subscriber, SubscriberDto>();
        CreateMap<SubscriberDto, Subscriber>();
        CreateMap<CUSubscriberDto, Subscriber>();
        
        CreateMap<Type, TypeDto>();
        CreateMap<TypeDto, Type>();
        CreateMap<CUTypeDto, Type>();
        
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<CUUserDto, User>();
        
        
        
    }
}
