using TelemetryPortal.Models;

public interface IClientRepository: IGenericRepository<Client>
{
    Client GetMostRecentClient();
}
