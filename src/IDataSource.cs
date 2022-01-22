namespace MultiIocDemo;

public interface IDataSource
{
	Task<IEnumerable<IMessage>> GetPendingMessagesAsync();
}