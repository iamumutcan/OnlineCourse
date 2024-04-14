using Application.Features.UserCourses.Constants;
using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.UserCourses.Commands.Delete;

public class DeleteUserCourseCommand : IRequest<DeletedUserCourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserCourses"];

    public class DeleteUserCourseCommandHandler : IRequestHandler<DeleteUserCourseCommand, DeletedUserCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly UserCourseBusinessRules _userCourseBusinessRules;

        public DeleteUserCourseCommandHandler(IMapper mapper, IUserCourseRepository userCourseRepository,
                                         UserCourseBusinessRules userCourseBusinessRules)
        {
            _mapper = mapper;
            _userCourseRepository = userCourseRepository;
            _userCourseBusinessRules = userCourseBusinessRules;
        }

        public async Task<DeletedUserCourseResponse> Handle(DeleteUserCourseCommand request, CancellationToken cancellationToken)
        {
            UserCourse? userCourse = await _userCourseRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCourseBusinessRules.UserCourseShouldExistWhenSelected(userCourse);

            await _userCourseRepository.DeleteAsync(userCourse!);

            DeletedUserCourseResponse response = _mapper.Map<DeletedUserCourseResponse>(userCourse);
            return response;
        }
    }
}