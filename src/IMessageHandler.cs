namespace MultiIocDemo;

public interface IMessageHandler
{
	Task SendMessagesAsync(IEnumerable<IMessage> messages);

	bool CanSendMessage(IMessage message);
	bool CanSendMessage(Type messageType);
}