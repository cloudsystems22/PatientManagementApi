using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Domain.Interfaces.Handlers;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> Handle(TCommand command);
}