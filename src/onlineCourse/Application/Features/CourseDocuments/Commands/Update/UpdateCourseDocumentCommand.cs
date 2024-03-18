using Application.Features.CourseDocuments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.CourseDocuments.Commands.Update;

public class UpdateCourseDocumentCommand : IRequest<UpdatedCourseDocumentResponse>
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public ContentType Type { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public Guid CourseContentId { get; set; }

    public class UpdateCourseDocumentCommandHandler : IRequestHandler<UpdateCourseDocumentCommand, UpdatedCourseDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseDocumentRepository _courseDocumentRepository;
        private readonly CourseDocumentBusinessRules _courseDocumentBusinessRules;

        public UpdateCourseDocumentCommandHandler(IMapper mapper, ICourseDocumentRepository courseDocumentRepository,
                                         CourseDocumentBusinessRules courseDocumentBusinessRules)
        {
            _mapper = mapper;
            _courseDocumentRepository = courseDocumentRepository;
            _courseDocumentBusinessRules = courseDocumentBusinessRules;
        }

        public async Task<UpdatedCourseDocumentResponse> Handle(UpdateCourseDocumentCommand request, CancellationToken cancellationToken)
        {
            CourseDocument? courseDocument = await _courseDocumentRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _courseDocumentBusinessRules.CourseDocumentShouldExistWhenSelected(courseDocument);
            courseDocument = _mapper.Map(request, courseDocument);

            await _courseDocumentRepository.UpdateAsync(courseDocument!);

            UpdatedCourseDocumentResponse response = _mapper.Map<UpdatedCourseDocumentResponse>(courseDocument);
            return response;
        }
    }
}