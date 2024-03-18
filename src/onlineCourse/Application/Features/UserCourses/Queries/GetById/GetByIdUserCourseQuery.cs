using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCourses.Queries.GetById;

public class GetByIdUserCourseQuery : IRequest<GetByIdUserCourseResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserCourseQueryHandler : IRequestHandler<GetByIdUserCourseQuery, GetByIdUserCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly UserCourseBusinessRules _userCourseBusinessRules;

        public GetByIdUserCourseQueryHandler(IMapper mapper, IUserCourseRepository userCourseRepository, UserCourseBusinessRules userCourseBusinessRules)
        {
            _mapper = mapper;
            _userCourseRepository = userCourseRepository;
            _userCourseBusinessRules = userCourseBusinessRules;
        }

        public async Task<GetByIdUserCourseResponse> Handle(GetByIdUserCourseQuery request, CancellationToken cancellationToken)
        {
            UserCourse? userCourse = await _userCourseRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCourseBusinessRules.UserCourseShouldExistWhenSelected(userCourse);

            GetByIdUserCourseResponse response = _mapper.Map<GetByIdUserCourseResponse>(userCourse);
            return response;
        }
    }
}