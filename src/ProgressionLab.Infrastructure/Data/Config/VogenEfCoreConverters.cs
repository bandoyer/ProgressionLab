using ProgressionLab.Core.ContributorAggregate;
using Vogen;

namespace ProgressionLab.Infrastructure.Data.Config;

[EfCoreConverter<ContributorId>]
[EfCoreConverter<ContributorName>]
internal partial class VogenEfCoreConverters;
