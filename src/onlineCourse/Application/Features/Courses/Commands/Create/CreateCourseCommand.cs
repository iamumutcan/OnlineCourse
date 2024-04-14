using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommand : IRequest<CreatedCourseResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int SortNumber { get; set; }
    public required CourseStatus Status { get; set; }
    public required Guid CategoryId { get; set; }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<CreatedCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = _mapper.Map<Course>(request);

            await _courseRepository.AddAsync(course);

            CreatedCourseResponse response = _mapper.Map<CreatedCourseResponse>(course);
            return response;
        }
    }
}