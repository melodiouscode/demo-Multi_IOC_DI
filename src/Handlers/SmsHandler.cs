﻿using MultiIocDemo.Messages;

namespace MultiIocDemo.Handlers;

public class SmsHandler : IMessageHandler
{
	public async Task SendMessagesAsync(IEnumerable<IMessage> messages)
	{
		var messagesArray = messages as IMessage[] ?? messages.ToArray();

		if (messagesArray.Any(x => !CanSendMessage(x)))
			throw new InvalidOperationException(
				"One or more of the provided messages can not be sent as an SMS Message.");

		foreach (var message in messagesArray.Cast<SmsMessage>())
		{
			await Task.Delay(100);
			// do some email sending!

			Console.WriteLine($"Sent SMS To {message.Number} saying '{message.Message}'.");
		}
	}

	public bool CanSendMessage(IMessage message)
	{
		return message.GetType() == typeof(SmsMessage);
	}

	public bool CanSendMessage(Type messageType)
	{
		return messageType == typeof(SmsMessage);
	}
}