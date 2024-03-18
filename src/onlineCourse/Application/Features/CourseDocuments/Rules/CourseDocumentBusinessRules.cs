using Application.Features.CourseDocuments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CourseDocuments.Rules;

public class CourseDocumentBusinessRules : BaseBusinessRules
{
    private readonly ICourseDocumentRepository _courseDocumentRepository;
    private readonly ILocalizationService _localizationService;

    public CourseDocumentBusinessRules(ICourseDocumentRepository courseDocumentRepository, ILocalizationService localizationService)
    {
        _courseDocumentRepository = courseDocumentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CourseDocumentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CourseDocumentShouldExistWhenSelected(CourseDocument? courseDocument)
    {
        if (courseDocument == null)
            await throwBusinessException(CourseDocumentsBusinessMessages.CourseDocumentNotExists);
    }

    public async Task CourseDocumentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CourseDocument? courseDocument = await _courseDocumentRepository.GetAsync(
            predicate: cd => cd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseDocumentShouldExistWhenSelected(courseDocument);
    }
}