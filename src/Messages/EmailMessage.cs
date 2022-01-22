namespace MultiIocDemo.Messages;

public class EmailMessage : IMessage
{
	public EmailMessage(string address, string subject, string message)
	{
		Address = address;
		Subject = subject;
		Message = message;
	}

	public string Address { get; set; }
	public string Subject { get; set; }
	public string Message { get; set; }
}