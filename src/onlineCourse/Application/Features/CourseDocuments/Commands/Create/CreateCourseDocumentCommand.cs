using Application.Features.CourseDocuments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.CourseDocuments.Commands.Create;

public class CreateCourseDocumentCommand : IRequest<CreatedCourseDocumentResponse>
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public ContentType Type { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public Guid CourseContentId { get; set; }

    public class CreateCourseDocumentCommandHandler : IRequestHandler<CreateCourseDocumentCommand, CreatedCourseDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseDocumentRepository _courseDocumentRepository;
        private readonly CourseDocumentBusinessRules _courseDocumentBusinessRules;

        public CreateCourseDocumentCommandHandler(IMapper mapper, ICourseDocumentRepository courseDocumentRepository,
                                         CourseDocumentBusinessRules courseDocumentBusinessRules)
        {
            _mapper = mapper;
            _courseDocumentRepository = courseDocumentRepository;
            _courseDocumentBusinessRules = courseDocumentBusinessRules;
        }

        public async Task<CreatedCourseDocumentResponse> Handle(CreateCourseDocumentCommand request, CancellationToken cancellationToken)
        {
            CourseDocument courseDocument = _mapper.Map<CourseDocument>(request);

            await _courseDocumentRepository.AddAsync(courseDocument);

            CreatedCourseDocumentResponse response = _mapper.Map<CreatedCourseDocumentResponse>(courseDocument);
            return response;
        }
    }
}