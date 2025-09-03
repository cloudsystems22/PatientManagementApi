namespace PatientManagement.Domain.Interfaces.Mediator;

public interface IMediator
{
    Task<TResult> Send<TResult>(ICommand<TResult> command);
    Task<TResult> Send<TResult>(IQuery<TResult> query);
}