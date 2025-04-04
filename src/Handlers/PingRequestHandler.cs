using ExampleWithoutMediatR.Interfaces;
using ExampleWithoutMediatR.Requests;

namespace ExampleWithoutMediatR.Handlers;

public class PingRequestHandler : IRequestHandler<PingRequest>
{
	public Task Handle(PingRequest request)
	{
		Console.WriteLine($"Ping received with message: {request.Message} at " + DateTime.UtcNow);
		return Task.CompletedTask;
	}
}