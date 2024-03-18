using Application.Features.CourseDocuments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseDocuments.Queries.GetById;

public class GetByIdCourseDocumentQuery : IRequest<GetByIdCourseDocumentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseDocumentQueryHandler : IRequestHandler<GetByIdCourseDocumentQuery, GetByIdCourseDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseDocumentRepository _courseDocumentRepository;
        private readonly CourseDocumentBusinessRules _courseDocumentBusinessRules;

        public GetByIdCourseDocumentQueryHandler(IMapper mapper, ICourseDocumentRepository courseDocumentRepository, CourseDocumentBusinessRules courseDocumentBusinessRules)
        {
            _mapper = mapper;
            _courseDocumentRepository = courseDocumentRepository;
            _courseDocumentBusinessRules = courseDocumentBusinessRules;
        }

        public async Task<GetByIdCourseDocumentResponse> Handle(GetByIdCourseDocumentQuery request, CancellationToken cancellationToken)
        {
            CourseDocument? courseDocument = await _courseDocumentRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _courseDocumentBusinessRules.CourseDocumentShouldExistWhenSelected(courseDocument);

            GetByIdCourseDocumentResponse response = _mapper.Map<GetByIdCourseDocumentResponse>(courseDocument);
            return response;
        }
    }
}