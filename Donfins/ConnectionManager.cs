namespace Dofins
{
    public interface IConnectionManager
    {
        Task HandleConnection(IConnection connection);
    }

    public class ConnectionManager : IConnectionManager
    {
        public async Task HandleConnection(IConnection connection)
        {
            await connection.KeepReceiving();
            await connection.Close();
        }
    }
}
