using Application.Features.CourseDocuments.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.CourseDocuments;

public class CourseDocumentManager : ICourseDocumentService
{
    private readonly ICourseDocumentRepository _courseDocumentRepository;
    private readonly CourseDocumentBusinessRules _courseDocumentBusinessRules;

    public CourseDocumentManager(ICourseDocumentRepository courseDocumentRepository, CourseDocumentBusinessRules courseDocumentBusinessRules)
    {
        _courseDocumentRepository = courseDocumentRepository;
        _courseDocumentBusinessRules = courseDocumentBusinessRules;
    }

    public async Task<CourseDocument?> GetAsync(
        Expression<Func<CourseDocument, bool>> predicate,
        Func<IQueryable<CourseDocument>, IIncludableQueryable<CourseDocument, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseDocument? courseDocument = await _courseDocumentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseDocument;
    }

    public async Task<IPaginate<CourseDocument>?> GetListAsync(
        Expression<Func<CourseDocument, bool>>? predicate = null,
        Func<IQueryable<CourseDocument>, IOrderedQueryable<CourseDocument>>? orderBy = null,
        Func<IQueryable<CourseDocument>, IIncludableQueryable<CourseDocument, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseDocument> courseDocumentList = await _courseDocumentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseDocumentList;
    }

    public async Task<CourseDocument> AddAsync(CourseDocument courseDocument)
    {
        CourseDocument addedCourseDocument = await _courseDocumentRepository.AddAsync(courseDocument);

        return addedCourseDocument;
    }

    public async Task<CourseDocument> UpdateAsync(CourseDocument courseDocument)
    {
        CourseDocument updatedCourseDocument = await _courseDocumentRepository.UpdateAsync(courseDocument);

        return updatedCourseDocument;
    }

    public async Task<CourseDocument> DeleteAsync(CourseDocument courseDocument, bool permanent = false)
    {
        CourseDocument deletedCourseDocument = await _courseDocumentRepository.DeleteAsync(courseDocument);

        return deletedCourseDocument;
    }
}
