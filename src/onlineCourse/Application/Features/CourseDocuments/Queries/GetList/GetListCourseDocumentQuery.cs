using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseDocuments.Queries.GetList;

public class GetListCourseDocumentQuery : IRequest<GetListResponse<GetListCourseDocumentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseDocumentQueryHandler : IRequestHandler<GetListCourseDocumentQuery, GetListResponse<GetListCourseDocumentListItemDto>>
    {
        private readonly ICourseDocumentRepository _courseDocumentRepository;
        private readonly IMapper _mapper;

        public GetListCourseDocumentQueryHandler(ICourseDocumentRepository courseDocumentRepository, IMapper mapper)
        {
            _courseDocumentRepository = courseDocumentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseDocumentListItemDto>> Handle(GetListCourseDocumentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseDocument> courseDocuments = await _courseDocumentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseDocumentListItemDto> response = _mapper.Map<GetListResponse<GetListCourseDocumentListItemDto>>(courseDocuments);
            return response;
        }
    }
}