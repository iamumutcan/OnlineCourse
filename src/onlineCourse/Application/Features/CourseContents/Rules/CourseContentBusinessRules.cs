using Application.Features.CourseContents.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.CourseContents.Rules;

public class CourseContentBusinessRules : BaseBusinessRules
{
    private readonly ICourseContentRepository _courseContentRepository;
    private readonly ILocalizationService _localizationService;

    public CourseContentBusinessRules(ICourseContentRepository courseContentRepository, ILocalizationService localizationService)
    {
        _courseContentRepository = courseContentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CourseContentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CourseContentShouldExistWhenSelected(CourseContent? courseContent)
    {
        if (courseContent == null)
            await throwBusinessException(CourseContentsBusinessMessages.CourseContentNotExists);
    }

    public async Task CourseContentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CourseContent? courseContent = await _courseContentRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseContentShouldExistWhenSelected(courseContent);
    }
}