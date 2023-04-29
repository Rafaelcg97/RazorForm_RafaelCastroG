using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorForm_RafaelCastroG.Models;

namespace RazorForm_RafaelCastroG.Controllers
{
    public class EquiposController1 : Controller
    {
        private readonly EquiposDbContext _equiposDbContext;

        public EquiposController1(EquiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }


        public IActionResult Index()
        {

            var listaDeTipos = (from m in _equiposDbContext.tipo_equipo select m).ToList();
            ViewData["listadoDeTipos"] = new SelectList(listaDeTipos, "id_tipo_equipo", "descripcion");

            var listaDeMarca= (from m in _equiposDbContext.marcas select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarca,"id_marcas","nombre_marca");

            var listaDeEstados = (from m in _equiposDbContext.estados_equipo select m).ToList();
            ViewData["listadoDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");

            var listadoDeEquipos=(from e in _equiposDbContext.equipos
                                  join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                  select new
                                  {
                                      nombre=e.nombre,
                                      descripcion=e.descripcion,
                                      marcaId=e.marca_id,
                                      marcaNombre=m.nombre_marca
                                  }).ToList();
            ViewData["listadoDeEquipos"] = listadoDeEquipos;

            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
