using Application.Features.CourseDocuments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseDocuments.Commands.Delete;

public class DeleteCourseDocumentCommand : IRequest<DeletedCourseDocumentResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseDocumentCommandHandler : IRequestHandler<DeleteCourseDocumentCommand, DeletedCourseDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseDocumentRepository _courseDocumentRepository;
        private readonly CourseDocumentBusinessRules _courseDocumentBusinessRules;

        public DeleteCourseDocumentCommandHandler(IMapper mapper, ICourseDocumentRepository courseDocumentRepository,
                                         CourseDocumentBusinessRules courseDocumentBusinessRules)
        {
            _mapper = mapper;
            _courseDocumentRepository = courseDocumentRepository;
            _courseDocumentBusinessRules = courseDocumentBusinessRules;
        }

        public async Task<DeletedCourseDocumentResponse> Handle(DeleteCourseDocumentCommand request, CancellationToken cancellationToken)
        {
            CourseDocument? courseDocument = await _courseDocumentRepository.GetAsync(predicate: cd => cd.Id == request.Id, cancellationToken: cancellationToken);
            await _courseDocumentBusinessRules.CourseDocumentShouldExistWhenSelected(courseDocument);

            await _courseDocumentRepository.DeleteAsync(courseDocument!);

            DeletedCourseDocumentResponse response = _mapper.Map<DeletedCourseDocumentResponse>(courseDocument);
            return response;
        }
    }
}