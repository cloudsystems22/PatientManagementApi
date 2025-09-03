using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Domain.Interfaces.Handlers;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> Handle(TQuery query);
}