using ProgressionLab.Core.ContributorAggregate;

namespace ProgressionLab.UseCases.Contributors.Delete;

public record DeleteContributorCommand(ContributorId ContributorId) : ICommand<Result>;
