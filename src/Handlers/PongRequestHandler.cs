using ExampleWithoutMediatR.Interfaces;
using ExampleWithoutMediatR.Requests;

namespace ExampleWithoutMediatR.Handlers;

public class PongRequestHandler : IRequestHandler<PongRequest, string>
{
	public Task<string> Handle(PongRequest request)
	{
		return Task.FromResult($"Pong response to message: {request.Message} at " + DateTime.UtcNow);
	}
}