using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Extensions.DependancyInjection;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> Send<TResult>(ICommand<TResult> command)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
        dynamic? handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
            throw new InvalidOperationException($"Handler não encontrado para {command.GetType().Name}");

        return await handler.Handle((dynamic)command);
    }

    public async Task<TResult> Send<TResult>(IQuery<TResult> query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        dynamic? handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
            throw new InvalidOperationException($"Handler não encontrado para {query.GetType().Name}");

        return await handler.Handle((dynamic)query);
    }
}

