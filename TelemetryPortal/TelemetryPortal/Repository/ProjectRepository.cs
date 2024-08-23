using TelemetryPortal.Data;
using TelemetryPortal.Models;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(TechtrendsContext context) : base(context)
    {
    }

    public Project GetEldestProject()
    {
        return _context.Projects.OrderByDescending(service => service.ProjectCreationDate).LastOrDefault();
    }
}

