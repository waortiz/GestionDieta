using GestionDieta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDieta.Controllers
{
    public class PacienteController : Controller
    {
        //
        // GET: /Paciente/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Paciente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Paciente/Crear
        public ActionResult Crear()
        {
            return View();
        }

        //
        // POST: /Paciente/Create
        [HttpPost]
        public JsonResult Crear(Paciente paciente)
        {
            try
            {
                var json = Json(new {  mensaje = "" });
                return json;
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        //
        // GET: /Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
