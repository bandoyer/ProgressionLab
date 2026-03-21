using ProgressionLab.Core.ContributorAggregate;

namespace ProgressionLab.UseCases.Contributors;
public record ContributorDto(ContributorId Id, ContributorName Name, PhoneNumber PhoneNumber);
