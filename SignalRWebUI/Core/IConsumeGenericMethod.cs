namespace SignalRWebUI.Core
{
	public interface IConsumeGenericMethod
	{
		Task<T> GetConsume<T>(string apiUrl, int? id= null);
		Task<bool> DeleteConsume(string apiUrl, int id);
		Task<bool> CreateConsume<T>(string apiUrl, T t);
		Task<bool> UpdateConsume<T>(string apiUrl, T t);

	}
}
