using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.UserCourses.Commands.Create;

public class CreateUserCourseCommand : IRequest<CreatedUserCourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid UserId { get; set; }
    public required Guid CourseId { get; set; }
    public required Boolean Confirmation { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserCourses"];

    public class CreateUserCourseCommandHandler : IRequestHandler<CreateUserCourseCommand, CreatedUserCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly UserCourseBusinessRules _userCourseBusinessRules;

        public CreateUserCourseCommandHandler(IMapper mapper, IUserCourseRepository userCourseRepository,
                                         UserCourseBusinessRules userCourseBusinessRules)
        {
            _mapper = mapper;
            _userCourseRepository = userCourseRepository;
            _userCourseBusinessRules = userCourseBusinessRules;
        }

        public async Task<CreatedUserCourseResponse> Handle(CreateUserCourseCommand request, CancellationToken cancellationToken)
        {
            UserCourse userCourse = _mapper.Map<UserCourse>(request);

            await _userCourseRepository.AddAsync(userCourse);

            CreatedUserCourseResponse response = _mapper.Map<CreatedUserCourseResponse>(userCourse);
            return response;
        }
    }
}