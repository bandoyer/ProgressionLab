using ProgressionLab.Core.ContributorAggregate;

namespace ProgressionLab.UseCases.Contributors.Update;

public record UpdateContributorCommand(ContributorId ContributorId, ContributorName NewName) : ICommand<Result<ContributorDto>>;
