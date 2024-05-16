using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Courses.Queries.GetById;

public class GetByIdCourseQuery : IRequest<GetByIdCourseResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, GetByIdCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public GetByIdCourseQueryHandler(IMapper mapper, ICourseRepository courseRepository, CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<GetByIdCourseResponse> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(
                include: c => c.Include(c => c.CourseContents),
                predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);
            // Sort the CourseContents by SortNumber
            course.CourseContents = course.CourseContents.OrderBy(cc => cc.SortNumber).ToList();

            GetByIdCourseResponse response = _mapper.Map<GetByIdCourseResponse>(course);
            return response;
        }
    }
}