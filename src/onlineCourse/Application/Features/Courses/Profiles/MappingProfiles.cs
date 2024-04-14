using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Courses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<Course, CreatedCourseResponse>();

        CreateMap<UpdateCourseCommand, Course>();
        CreateMap<Course, UpdatedCourseResponse>();

        CreateMap<DeleteCourseCommand, Course>();
        CreateMap<Course, DeletedCourseResponse>();

        CreateMap<Course, GetByIdCourseResponse>();

        CreateMap<Course, GetListCourseListItemDto>();
        CreateMap<IPaginate<Course>, GetListResponse<GetListCourseListItemDto>>();
    }
}