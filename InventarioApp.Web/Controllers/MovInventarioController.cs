using InventarioApp.Entities;
using InventarioApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace InventarioApp.Web.Controllers
{
    public class MovInventarioController : Controller
    {
        private readonly IMovInventarioService service = new MovInventarioService();

        public ActionResult Index(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            var lista = service.Consultar(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
            return View(lista);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(MovInventario model)
        {
            if (ModelState.IsValid)
            {
                bool ok = service.Insertar(model);

                if (ok)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "No se pudo guardar.");
            }

            return View(model);
        }

        public ActionResult Edit(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            var item = service.ObtenerPorId(codCia, companiaVenta3, almacenVenta, tipoMovimiento, tipoDocumento, nroDocumento, codItem2);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovInventario item)
        {
            if (ModelState.IsValid)
            {
                service.Actualizar(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public ActionResult Delete(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            var item = service.ObtenerPorId(codCia, companiaVenta3, almacenVenta, tipoMovimiento, tipoDocumento, nroDocumento, codItem2);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string codCia, string companiaVenta3, string almacenVenta, string tipoMovimiento, string tipoDocumento, string nroDocumento, string codItem2)
        {
            service.Eliminar(codCia, companiaVenta3, almacenVenta, tipoMovimiento, tipoDocumento, nroDocumento, codItem2);
            return RedirectToAction("Index");
        }
    }
}