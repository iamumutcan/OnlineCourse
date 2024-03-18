using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCourses.Commands.Update;

public class UpdateUserCourseCommand : IRequest<UpdatedUserCourseResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }

    public class UpdateUserCourseCommandHandler : IRequestHandler<UpdateUserCourseCommand, UpdatedUserCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly UserCourseBusinessRules _userCourseBusinessRules;

        public UpdateUserCourseCommandHandler(IMapper mapper, IUserCourseRepository userCourseRepository,
                                         UserCourseBusinessRules userCourseBusinessRules)
        {
            _mapper = mapper;
            _userCourseRepository = userCourseRepository;
            _userCourseBusinessRules = userCourseBusinessRules;
        }

        public async Task<UpdatedUserCourseResponse> Handle(UpdateUserCourseCommand request, CancellationToken cancellationToken)
        {
            UserCourse? userCourse = await _userCourseRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCourseBusinessRules.UserCourseShouldExistWhenSelected(userCourse);
            userCourse = _mapper.Map(request, userCourse);

            await _userCourseRepository.UpdateAsync(userCourse!);

            UpdatedUserCourseResponse response = _mapper.Map<UpdatedUserCourseResponse>(userCourse);
            return response;
        }
    }
}