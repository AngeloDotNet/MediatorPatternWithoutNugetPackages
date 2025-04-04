using ExampleWithoutMediatR.Interfaces;

namespace ExampleWithoutMediatR.Services;

public class Mediator : IMediator
{
	private readonly IServiceProvider _serviceProvider;

	public Mediator(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task Send<TRequest>(TRequest request)
	{
		var handler = _serviceProvider.GetService(typeof(IRequestHandler<TRequest>)) as IRequestHandler<TRequest>;
		if (handler == null)
		{
			throw new InvalidOperationException($"Handler for request type {typeof(TRequest).Name} not found");
		}
		await handler.Handle(request);
	}

	public async Task<TResponse> Send<TRequest, TResponse>(TRequest request)
	{
		var handler = _serviceProvider.GetService(typeof(IRequestHandler<TRequest, TResponse>)) as IRequestHandler<TRequest, TResponse>;
		if (handler == null)
		{
			throw new InvalidOperationException($"Handler for request type {typeof(TRequest).Name} not found");
		}
		return await handler.Handle(request);
	}
}