using ProgressionLab.Core.ContributorAggregate;

namespace ProgressionLab.UseCases.Contributors.Get;

public record GetContributorQuery(ContributorId ContributorId) : IQuery<Result<ContributorDto>>;
