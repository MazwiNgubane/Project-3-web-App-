using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var clients = await _clientRepository.GetAllAsync();
            return View(clients);
        }

        // GET: Clients
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetByIdAsync(id.Value);
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
                 await _clientRepository.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(client);
         }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int id)
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

        // Other actions
    }
}












