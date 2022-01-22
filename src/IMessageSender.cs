namespace MultiIocDemo;

public interface IMessageSender
{
	Task SendMessagesAsync(IEnumerable<IMessage> messages);
}