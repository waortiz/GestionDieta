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
        public static List<Paciente> pacientes = new List<Paciente>();

        public ActionResult Index()
        {
            return View(pacientes);
        }

        public ActionResult Crear()
        {
            Paciente paciente = new Paciente();

            var tiposDocumento = new List<TipoDocumento>();
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" });

            ViewBag.TiposDocumento = tiposDocumento.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdTipoDocumento.ToString()
            });

            return View(paciente);
        }

        [HttpPost]
        public JsonResult CrearAJAX(Paciente paciente)
        {
            try
            {
                paciente.IdPaciente = pacientes.Count + 1;
                if (paciente.TipoDocumento.IdTipoDocumento == 1)
                {
                    paciente.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" };
                }
                else if (paciente.TipoDocumento.IdTipoDocumento == 2)
                {
                    paciente.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" };
                }

                pacientes.Add(paciente);
                var json = Json(new { mensaje = "" });
                return json;
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Crear(Paciente paciente)
        {
            if (paciente.TipoDocumento.IdTipoDocumento == 1)
            {
                paciente.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" };
            }
            else if (paciente.TipoDocumento.IdTipoDocumento == 2)
            {
                paciente.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" };
            }
            if (paciente.IdPaciente == 0)
            {
                paciente.IdPaciente = pacientes.Count + 1;
                pacientes.Add(paciente);
            }
            else
            {
                ActualizarPaciente(paciente);
            }

            var tiposDocumento = new List<TipoDocumento>();
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" });

            ViewBag.TiposDocumento = tiposDocumento.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdTipoDocumento.ToString()
            });

            return View(new Paciente());
        }

        public ActionResult Editar(long id)
        {
            var tiposDocumento = new List<TipoDocumento>();
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" });
            ViewBag.TiposDocumento = tiposDocumento.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdTipoDocumento.ToString()
            });

            Paciente paciente = pacientes.FirstOrDefault(p => p.IdPaciente == id);

            return View("Crear", paciente);
        }

        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            try
            {
                ActualizarPaciente(paciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Eliminar(long id)
        {
            try
            {
                Paciente pacienteActual = pacientes.FirstOrDefault(p => p.IdPaciente == id);
                pacientes.Remove(pacienteActual);
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }
    
        private static void ActualizarPaciente(Paciente paciente)
        {
            Paciente pacienteActual = pacientes.FirstOrDefault(p => p.IdPaciente == paciente.IdPaciente);
            pacienteActual.FechaNacimiento = paciente.FechaNacimiento;
            pacienteActual.NumeroDocumento = paciente.NumeroDocumento;
            pacienteActual.PrimerApellido = paciente.PrimerApellido;
            pacienteActual.PrimerNombre = paciente.PrimerNombre;
            pacienteActual.SegundoApellido = paciente.SegundoApellido;
            pacienteActual.SegundoNombre = paciente.SegundoNombre;
            pacienteActual.Sexo = paciente.Sexo;

            if (paciente.TipoDocumento.IdTipoDocumento == 1)
            {
                pacienteActual.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 1, Nombre = "Cédula de Ciudadanía" };
            }
            else if (paciente.TipoDocumento.IdTipoDocumento == 2)
            {
                pacienteActual.TipoDocumento = new TipoDocumento() { IdTipoDocumento = 2, Nombre = "Tarjeta de Identidad" };
            }
        }
    }
}
