using MultiIocDemo.Messages;

namespace MultiIocDemo.Handlers;

public class EmailHandler : IMessageHandler
{
	public async Task SendMessagesAsync(IEnumerable<IMessage> messages)
	{
		var messagesArray = messages as IMessage[] ?? messages.ToArray();

		if (messagesArray.Any(x => !CanSendMessage(x)))
			throw new InvalidOperationException("One or more of the provided messages can not be sent as an Email.");

		foreach (var message in messagesArray.Cast<EmailMessage>())
		{
			await Task.Delay(1000);
			
			// do some email sending!
			Console.WriteLine($"Sent Email To {message.Address} with the subject '{message.Subject}'.");
		}
	}

	public bool CanSendMessage(IMessage message)
	{
		return message.GetType() == typeof(EmailMessage);
	}

	public bool CanSendMessage(Type messageType)
	{
		return messageType == typeof(EmailMessage);
	}
}