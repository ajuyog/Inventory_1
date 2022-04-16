using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class ElementoController: Controller
    {
        private readonly IRepositorioElemento repositorioElemento;

        public ElementoController(IRepositorioElemento repositorioElemento)
        {
            this.repositorioElemento = repositorioElemento;
        }

        public async Task<IActionResult> Index()
        {
            var elementos = await repositorioElemento.Obtener();

            return View(elementos);
        }

        public IActionResult CrearElemento()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> CrearElemento(Elementos elementos)
        {
            if (!ModelState.IsValid)
            {
                return View(elementos);
            }

            var elementExist = await repositorioElemento.ExistElemento(elementos.idElement);

            if (!elementExist)
            {
                ModelState.AddModelError(nameof(elementos.idElement),$"El Elemento {elementos.idElement} ya exite");

                return View(elementos);
            }

            await repositorioElemento.CrearElemento(elementos);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<ActionResult> Editar(int idElement)
        {
           var elemento = await repositorioElemento.ObtenerElemento(idElement);

            if (elemento is null)
            {
                return RedirectToAction("NoEncontrado");
            }

            return View(elemento);
        }

        [HttpPost]

        public async Task<ActionResult> Editar(Elementos elementos)
        {
            await repositorioElemento.Actualizar(elementos);

            return RedirectToAction("Index");
        }
    }
}
