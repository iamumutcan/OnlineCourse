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
        CreateMap<CreateCourseDocumentCommand, CourseDocument>();
        CreateMap<CourseDocument, CreatedCourseDocumentResponse>();

        CreateMap<UpdateCourseDocumentCommand, CourseDocument>();
        CreateMap<CourseDocument, UpdatedCourseDocumentResponse>();

        CreateMap<DeleteCourseDocumentCommand, CourseDocument>();
        CreateMap<CourseDocument, DeletedCourseDocumentResponse>();

        CreateMap<CourseDocument, GetByIdCourseDocumentResponse>();

        CreateMap<CourseDocument, GetListCourseDocumentListItemDto>();
        CreateMap<IPaginate<CourseDocument>, GetListResponse<GetListCourseDocumentListItemDto>>();
    }
}