using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseContents.Queries.GetList;

public class GetListCourseContentQuery : IRequest<GetListResponse<GetListCourseContentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseContentQueryHandler : IRequestHandler<GetListCourseContentQuery, GetListResponse<GetListCourseContentListItemDto>>
    {
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly IMapper _mapper;

        public GetListCourseContentQueryHandler(ICourseContentRepository courseContentRepository, IMapper mapper)
        {
            _courseContentRepository = courseContentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseContentListItemDto>> Handle(GetListCourseContentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseContent> courseContents = await _courseContentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseContentListItemDto> response = _mapper.Map<GetListResponse<GetListCourseContentListItemDto>>(courseContents);
            return response;
        }
    }
}