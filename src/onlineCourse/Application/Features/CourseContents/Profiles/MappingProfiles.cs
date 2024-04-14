using Application.Features.CourseContents.Commands.Create;
using Application.Features.CourseContents.Commands.Delete;
using Application.Features.CourseContents.Commands.Update;
using Application.Features.CourseContents.Queries.GetById;
using Application.Features.CourseContents.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CourseContents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCourseContentCommand, CourseContent>();
        CreateMap<CourseContent, CreatedCourseContentResponse>();

        CreateMap<UpdateCourseContentCommand, CourseContent>();
        CreateMap<CourseContent, UpdatedCourseContentResponse>();

        CreateMap<DeleteCourseContentCommand, CourseContent>();
        CreateMap<CourseContent, DeletedCourseContentResponse>();

        CreateMap<CourseContent, GetByIdCourseContentResponse>();

        CreateMap<CourseContent, GetListCourseContentListItemDto>();
        CreateMap<IPaginate<CourseContent>, GetListResponse<GetListCourseContentListItemDto>>();
    }
}