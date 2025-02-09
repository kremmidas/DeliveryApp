﻿using DeliveryApp.Core.ContributorAggregate;
using DeliveryApp.Core.ContributorAggregate.Specifications;

namespace DeliveryApp.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetContributorHandler(IReadRepository<Contributor> _repository)
  : IQueryHandler<GetContributorQuery, Result<ContributorDto>>
{
  public async Task<Result<ContributorDto>> Handle(GetContributorQuery request, CancellationToken cancellationToken)
  {
    var spec = new ContributorByIdSpec(request.ContributorId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ContributorDto(entity.Id, entity.Name, entity.PhoneNumber?.Number ?? "");
  }
}
