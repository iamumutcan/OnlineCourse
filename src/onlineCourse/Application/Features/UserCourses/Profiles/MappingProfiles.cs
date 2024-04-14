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
        CreateMap<CreateUserCourseCommand, UserCourse>();
        CreateMap<UserCourse, CreatedUserCourseResponse>();

        CreateMap<UpdateUserCourseCommand, UserCourse>();
        CreateMap<UserCourse, UpdatedUserCourseResponse>();

        CreateMap<DeleteUserCourseCommand, UserCourse>();
        CreateMap<UserCourse, DeletedUserCourseResponse>();

        CreateMap<UserCourse, GetByIdUserCourseResponse>();

        CreateMap<UserCourse, GetListUserCourseListItemDto>();
        CreateMap<IPaginate<UserCourse>, GetListResponse<GetListUserCourseListItemDto>>();
    }
}