using TelemetryPortal.Data;
using TelemetryPortal.Models;

public class ServiceRepository : GenericRepository<Client>, IClientRepository
{
    public ServiceRepository(TechtrendsContext context) : base(context)
    {
    }

    public Client GetMostRecentClient()
    {
        return _context.Set<Client>().OrderByDescending(service => service.DateOnboarded).FirstOrDefault();
    }
}

