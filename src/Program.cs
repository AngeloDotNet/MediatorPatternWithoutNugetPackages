using ExampleWithoutMediatR.Interfaces;
using ExampleWithoutMediatR.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleWithoutMediatR;

class Program
{
	static async Task Main(string[] args)
	{
		var serviceCollection = new ServiceCollection();
		var startup = new Startup();
		startup.ConfigureServices(serviceCollection);

		var serviceProvider = serviceCollection.BuildServiceProvider();
		var mediator = serviceProvider.GetService<IMediator>();

		var pingRequest = new PingRequest { Message = "Hello Ping!" };
		await mediator.Send(pingRequest);

		await Task.Delay(2000);

		var pongRequest = new PongRequest { Message = "Hello Pong!" };
		var response = await mediator.Send<PongRequest, string>(pongRequest);
		Console.WriteLine(response);

		Console.Read();
	}
}