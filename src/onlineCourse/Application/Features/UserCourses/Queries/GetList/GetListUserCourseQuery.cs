using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserCourses.Queries.GetList;

public class GetListUserCourseQuery : IRequest<GetListResponse<GetListUserCourseListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserCourseQueryHandler : IRequestHandler<GetListUserCourseQuery, GetListResponse<GetListUserCourseListItemDto>>
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IMapper _mapper;

        public GetListUserCourseQueryHandler(IUserCourseRepository userCourseRepository, IMapper mapper)
        {
            _userCourseRepository = userCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserCourseListItemDto>> Handle(GetListUserCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserCourse> userCourses = await _userCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserCourseListItemDto> response = _mapper.Map<GetListResponse<GetListUserCourseListItemDto>>(userCourses);
            return response;
        }
    }
}