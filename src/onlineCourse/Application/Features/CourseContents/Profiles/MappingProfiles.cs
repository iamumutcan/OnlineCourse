using Application.Features.CourseContents.Commands.Create;
using Application.Features.CourseContents.Commands.Delete;
using Application.Features.CourseContents.Commands.Update;
using Application.Features.CourseContents.Queries.GetById;
using Application.Features.CourseContents.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CourseContents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseContent, CreateCourseContentCommand>().ReverseMap();
        CreateMap<CourseContent, CreatedCourseContentResponse>().ReverseMap();
        CreateMap<CourseContent, UpdateCourseContentCommand>().ReverseMap();
        CreateMap<CourseContent, UpdatedCourseContentResponse>().ReverseMap();
        CreateMap<CourseContent, DeleteCourseContentCommand>().ReverseMap();
        CreateMap<CourseContent, DeletedCourseContentResponse>().ReverseMap();
        CreateMap<CourseContent, GetByIdCourseContentResponse>().ReverseMap();
        CreateMap<CourseContent, GetListCourseContentListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseContent>, GetListResponse<GetListCourseContentListItemDto>>().ReverseMap();
    }
}