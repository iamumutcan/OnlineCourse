using Application.Features.CourseDocuments.Commands.Create;
using Application.Features.CourseDocuments.Commands.Delete;
using Application.Features.CourseDocuments.Commands.Update;
using Application.Features.CourseDocuments.Queries.GetById;
using Application.Features.CourseDocuments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CourseDocuments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseDocument, CreateCourseDocumentCommand>().ReverseMap();
        CreateMap<CourseDocument, CreatedCourseDocumentResponse>().ReverseMap();
        CreateMap<CourseDocument, UpdateCourseDocumentCommand>().ReverseMap();
        CreateMap<CourseDocument, UpdatedCourseDocumentResponse>().ReverseMap();
        CreateMap<CourseDocument, DeleteCourseDocumentCommand>().ReverseMap();
        CreateMap<CourseDocument, DeletedCourseDocumentResponse>().ReverseMap();
        CreateMap<CourseDocument, GetByIdCourseDocumentResponse>().ReverseMap();
        CreateMap<CourseDocument, GetListCourseDocumentListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseDocument>, GetListResponse<GetListCourseDocumentListItemDto>>().ReverseMap();
    }
}