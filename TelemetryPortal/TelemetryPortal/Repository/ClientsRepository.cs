using TelemetryPortal.Data;
using TelemetryPortal.Models;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(TechtrendsContext context) : base(context)
    {
    }

    public Client GetMostRecentClient()
    {
        return _context.Clients.OrderByDescending(service => service.DateOnboarded).FirstOrDefault();
    }
}

