using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal.Data;
using TelemetryPortal.Models;

namespace TelemetryPortal.Contoller
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository context)
        {
            _projectRepository = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAll();
            return View(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  _projectRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectDescription,ProjectCreationDate,ProjectStatus,ClientId")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.ProjectId = Guid.NewGuid();
                _projectRepository.AddAsync(project);
                await _projectRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project =  _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProjectId,ProjectName,ProjectDescription,ProjectCreationDate,ProjectStatus,ClientId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _projectRepository.Update(project);
                    await _projectRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var project = _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var clients = _projectRepository.Find(c => c.ClientId == id);

            var project = clients.FirstOrDefault();
            if (project != null)
            {
                _projectRepository.Remove(project);
            }

            await _projectRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {
            return _projectRepository.Any(e => e.ProjectId == id);
        }
    }
}
