namespace MultiIocDemo;

public class MessageSender : IMessageSender
{
	private readonly IEnumerable<IMessageHandler> _handlers;

	public MessageSender(IEnumerable<IMessageHandler> handlers)
	{
		_handlers = handlers;
	}

	public Task SendMessagesAsync(IEnumerable<IMessage> messages)
	{
		var messagesArray = messages.ToArray();
		var typesToSend = messagesArray.Select(x => x.GetType()).Distinct().ToArray();

		if (typesToSend.Any(x => _handlers.All(h => !h.CanSendMessage(x))))
			throw new InvalidOperationException(
				"One or more messages are not of a type that can be sent. No messages have been sent.");

		var tasks = (from type in typesToSend
			let handler = _handlers.Single(x => x.CanSendMessage(type))
			select handler.SendMessagesAsync(messagesArray.Where(x => x.GetType() == type)));

		return Task.WhenAll(tasks);
	}
}