using MultiIocDemo.Messages;

namespace MultiIocDemo;

public class FakeDataSource : IDataSource
{
	public async Task<IEnumerable<IMessage>> GetPendingMessagesAsync()
	{
		await Task.Delay(1000);

		var messages = new List<IMessage>();

		var rand = new Random();

		for (var x = 0; x < rand.Next(5, 20); x++)
			messages.Add(new EmailMessage($"fake{x}@fake.fake", $"I am a subject - {x}", $"I am a message - {x}"));

		for (var x = 0; x < rand.Next(5, 20); x++)
			messages.Add(new SmsMessage(x.ToString(), $"I am an SMS Message - {x}"));

		return messages;
	}
}