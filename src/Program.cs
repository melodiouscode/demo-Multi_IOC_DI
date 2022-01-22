using Microsoft.Extensions.DependencyInjection;
using MultiIocDemo;
using MultiIocDemo.Handlers;

var services = new ServiceCollection()
	.AddSingleton<IMessageHandler, EmailHandler>()
	.AddSingleton<IMessageHandler, SmsHandler>()
	.AddSingleton<IDataSource, FakeDataSource>()
	.AddSingleton<IMessageSender, MessageSender>()
	.BuildServiceProvider();


var dataSource = services.GetService<IDataSource>();

var messages = await dataSource!.GetPendingMessagesAsync();

var sender = services.GetService<IMessageSender>();

await sender!.SendMessagesAsync(messages);

Console.ReadKey();