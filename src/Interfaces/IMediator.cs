namespace ExampleWithoutMediatR.Interfaces;

public interface IMediator
{
	Task Send<TRequest>(TRequest request);
	Task<TResponse> Send<TRequest, TResponse>(TRequest request);
}