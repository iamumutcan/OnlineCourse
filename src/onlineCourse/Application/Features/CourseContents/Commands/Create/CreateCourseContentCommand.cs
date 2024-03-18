using Application.Features.CourseContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseContents.Commands.Create;

public class CreateCourseContentCommand : IRequest<CreatedCourseContentResponse>
{
    public string Summary { get; set; }
    public Guid CourseId { get; set; }

    public class CreateCourseContentCommandHandler : IRequestHandler<CreateCourseContentCommand, CreatedCourseContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly CourseContentBusinessRules _courseContentBusinessRules;

        public CreateCourseContentCommandHandler(IMapper mapper, ICourseContentRepository courseContentRepository,
                                         CourseContentBusinessRules courseContentBusinessRules)
        {
            _mapper = mapper;
            _courseContentRepository = courseContentRepository;
            _courseContentBusinessRules = courseContentBusinessRules;
        }

        public async Task<CreatedCourseContentResponse> Handle(CreateCourseContentCommand request, CancellationToken cancellationToken)
        {
            CourseContent courseContent = _mapper.Map<CourseContent>(request);

            await _courseContentRepository.AddAsync(courseContent);

            CreatedCourseContentResponse response = _mapper.Map<CreatedCourseContentResponse>(courseContent);
            return response;
        }
    }
}