using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCourses.Commands.Create;

public class CreateUserCourseCommand : IRequest<CreatedUserCourseResponse>
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public Boolean Confirmation { get; set; }

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