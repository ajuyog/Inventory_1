﻿using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class AsignacionController: Controller
    {
        private readonly IRepositorioAsignacion repositorioAsignacion;

        public AsignacionController(IRepositorioAsignacion repositorioAsignacion)
        {
            this.repositorioAsignacion = repositorioAsignacion;
        }

        public async Task<IActionResult> Index()
        {
            var asignaciones = await repositorioAsignacion.Obtener();

            return View(asignaciones);
        }

       
        public IActionResult CrearAsignacion()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Editar(Asignaciones asignaciones)
        {
            var personId = repositorioAsignacion.Actualizar(Pers)
                
        }
        
        [HttpPost]

        public async Task<IActionResult> CrearAsignacion(Asignaciones asignaciones)
        {
            if (!ModelState.IsValid) 
            { 
                return View(asignaciones); 
            }

            var asigExiste = await repositorioAsignacion.ExisteAsig(asignaciones.Assembly_idAssembly, asignaciones.Person_idPerson);

            if (asigExiste)
            {
                ModelState.AddModelError(nameof(asignaciones.Person_idPerson), $"El ensamble {asignaciones.Assembly_idAssembly} ya esta asignado al usuario {asignaciones.Person_idPerson}");

                return View(asignaciones);
            }

            await repositorioAsignacion.CrearAsignacion(asignaciones);

            return RedirectToAction("Index");
        }

       /* [HttpGet]

        public async Task<ActionResult> Editar(int Assembly_idAssembly, string Person_idPerson)
        {
            var personId = await repositorioAsignacion.ObtenerAsig(Person_idPerson);
        }*/

    }
}
