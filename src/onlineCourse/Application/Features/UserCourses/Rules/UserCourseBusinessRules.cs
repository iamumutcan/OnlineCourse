using Application.Features.UserCourses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserCourses.Rules;

public class UserCourseBusinessRules : BaseBusinessRules
{
    private readonly IUserCourseRepository _userCourseRepository;
    private readonly ILocalizationService _localizationService;

    public UserCourseBusinessRules(IUserCourseRepository userCourseRepository, ILocalizationService localizationService)
    {
        _userCourseRepository = userCourseRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserCoursesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserCourseShouldExistWhenSelected(UserCourse? userCourse)
    {
        if (userCourse == null)
            await throwBusinessException(UserCoursesBusinessMessages.UserCourseNotExists);
    }

    public async Task UserCourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserCourse? userCourse = await _userCourseRepository.GetAsync(
            predicate: uc => uc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserCourseShouldExistWhenSelected(userCourse);
    }
}