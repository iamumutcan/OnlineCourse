using Application.Features.CourseContents.Rules;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CourseContents.Queries.GetById;

public class GetByIdCourseContentQuery : IRequest<GetByIdCourseContentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseContentQueryHandler : IRequestHandler<GetByIdCourseContentQuery, GetByIdCourseContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly CourseContentBusinessRules _courseContentBusinessRules;

        public GetByIdCourseContentQueryHandler(IMapper mapper, ICourseContentRepository courseContentRepository, CourseContentBusinessRules courseContentBusinessRules)
        {
            _mapper = mapper;
            _courseContentRepository = courseContentRepository;
            _courseContentBusinessRules = courseContentBusinessRules;
        }

        public async Task<GetByIdCourseContentResponse> Handle(GetByIdCourseContentQuery request, CancellationToken cancellationToken)
        {
            CourseContent? courseContent = await _courseContentRepository.GetAsync(
                include: c => c.Include(c => c.CourseDocuments),
                predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseContentBusinessRules.CourseContentShouldExistWhenSelected(courseContent);

        

            GetByIdCourseContentResponse response = _mapper.Map<GetByIdCourseContentResponse>(courseContent);
            return response;
        }
    }
}