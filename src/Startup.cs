using ExampleWithoutMediatR.Handlers;
using ExampleWithoutMediatR.Interfaces;
using ExampleWithoutMediatR.Requests;
using ExampleWithoutMediatR.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleWithoutMediatR;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddSingleton<IMediator, Mediator>();
		services.AddTransient<IRequestHandler<PingRequest>, PingRequestHandler>();
		services.AddTransient<IRequestHandler<PongRequest, string>, PongRequestHandler>();
	}
}