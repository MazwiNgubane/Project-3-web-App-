using TelemetryPortal.Models;

public interface IProjectRepository : IGenericRepository<Project>
{
    Project GetEldestProject();
}
