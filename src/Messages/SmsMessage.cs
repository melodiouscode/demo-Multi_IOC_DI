namespace MultiIocDemo.Messages;

public class SmsMessage : IMessage
{
	public SmsMessage(string number, string message)
	{
		Number = number;
		Message = message;
	}
	public string Number { get; set; }
	public string Message { get; set; }
}