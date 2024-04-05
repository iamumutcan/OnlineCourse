using Application.Features.UserCourses.Commands.Create;
using Application.Features.UserCourses.Commands.Delete;
using Application.Features.UserCourses.Commands.Update;
using Application.Features.UserCourses.Queries.GetById;
using Application.Features.UserCourses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserCourse, CreateUserCourseCommand>().ReverseMap();
        CreateMap<UserCourse, CreatedUserCourseResponse>().ReverseMap();
        CreateMap<UserCourse, UpdateUserCourseCommand>().ReverseMap();
        CreateMap<UserCourse, UpdatedUserCourseResponse>().ReverseMap();
        CreateMap<UserCourse, DeleteUserCourseCommand>().ReverseMap();
        CreateMap<UserCourse, DeletedUserCourseResponse>().ReverseMap();
        CreateMap<UserCourse, GetByIdUserCourseResponse>().ReverseMap();
        CreateMap<UserCourse, GetListUserCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserCourse>, GetListResponse<GetListUserCourseListItemDto>>().ReverseMap();
    }
}