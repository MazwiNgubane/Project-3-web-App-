using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TelemetryPortal.Components.Pages.Clients;
using TelemetryPortal.Data;
using TelemetryPortal.Models;

namespace TelemetryPortal.Contoller
{

    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _clientRepository.GetAll();
            return View(clients);
        }

        // GET: Clients
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  _clientRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        
         // GET: Clients/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Clients/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("ClientId,ClientName,PrimaryContactEmail,DateOnboarded")] Client client)
         {
             if (ModelState.IsValid)
             {
                 client.ClientId = Guid.NewGuid();
                 _clientRepository.Add(client);
                 await _clientRepository.SaveChanges();
                 return RedirectToAction(nameof(Index));
             }
             return View(client);
        }

        //GET: Clients/Delete/5
         


        // GET: Clients/Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  _clientRepository.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clients =  _clientRepository.Find(c => c.ClientId == id);

            var client = clients.FirstOrDefault();
            if (client != null)
            {
                _clientRepository.Remove(client);
            }

            await _clientRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(Guid id)
        {
            return _clientRepository.Any(e => e.ClientId == id);
        }

        
    }
}














