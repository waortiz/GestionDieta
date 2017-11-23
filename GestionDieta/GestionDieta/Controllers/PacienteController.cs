using GestionDieta.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GestionDieta.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private static Datos.GestionDietaContext contexto = new Datos.GestionDietaContext();

        public ActionResult Index()
        {
            List<Paciente> pacientes = contexto.Pacientes.OrderBy(p => p.IdPaciente).Select(p => new Paciente()
            {
                IdPaciente = p.IdPaciente,
                PrimerApellido = p.PrimerApellido,
                SegundoApellido = p.SegundoApellido,
                PrimerNombre = p.PrimerNombre,
                SegundoNombre = p.SegundoNombre,
                NumeroDocumento = p.NumeroDocumento,
                TipoDocumento = new TipoDocumento() { Nombre = p.TipoDocumento.Nombre }
            }).ToList();

            return View(pacientes);
        }

        public ActionResult Grafico()
        {
            var pacientes = contexto.Pacientes.GroupBy(p => p.FechaNacimiento.Year).Select(p=> new { Year = p.Key, Cantidad = p.Count() } );
            var datosGrafico = "[";
            if (pacientes.Count() > 0)
            {
                foreach (var valor in pacientes)
                {
                    datosGrafico += "['" + valor.Year + "', " + valor.Cantidad + "],";
                }
                datosGrafico = datosGrafico.Substring(0, datosGrafico.Length - 1);
                datosGrafico += "]";
            }
            else
            {
                datosGrafico = "[]";
            }

            ViewBag.DatosGrafico = datosGrafico;
            return View();
        }

        public ActionResult Crear()
        {
            Paciente paciente = new Paciente();

            var tiposDocumento = contexto.TiposDocumento.OrderBy(t => t.Nombre).Select(t => new TipoDocumento()
            {
                IdTipoDocumento = t.IdTipoDocumento,
                Nombre = t.Nombre
            }).ToList();

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
                if (paciente.IdPaciente == 0)
                {
                    Datos.Paciente pacienteNuevo = new Datos.Paciente();
                    pacienteNuevo.FechaNacimiento = paciente.FechaNacimiento.Value;
                    pacienteNuevo.IdTipoDocumento = paciente.TipoDocumento.IdTipoDocumento;
                    pacienteNuevo.NumeroDocumento = paciente.NumeroDocumento;
                    pacienteNuevo.PrimerApellido = paciente.PrimerApellido;
                    pacienteNuevo.PrimerNombre = paciente.PrimerNombre;
                    pacienteNuevo.SegundoApellido = paciente.SegundoApellido;
                    pacienteNuevo.SegundoNombre = paciente.SegundoNombre;
                    pacienteNuevo.Sexo = paciente.Sexo;
                    contexto.Pacientes.Add(pacienteNuevo);
                }
                else
                {
                    Datos.Paciente pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.IdPaciente == paciente.IdPaciente);
                    if (pacienteActual != null)
                    {
                        pacienteActual.FechaNacimiento = paciente.FechaNacimiento.Value;
                        pacienteActual.IdTipoDocumento = paciente.TipoDocumento.IdTipoDocumento;
                        pacienteActual.NumeroDocumento = paciente.NumeroDocumento;
                        pacienteActual.PrimerApellido = paciente.PrimerApellido;
                        pacienteActual.PrimerNombre = paciente.PrimerNombre;
                        pacienteActual.SegundoApellido = paciente.SegundoApellido;
                        pacienteActual.SegundoNombre = paciente.SegundoNombre;
                        pacienteActual.Sexo = paciente.Sexo;
                    }
                }
                contexto.SaveChanges();

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
            try
            {
                if (paciente.IdPaciente == 0)
                {
                    Datos.Paciente pacienteNuevo = new Datos.Paciente();
                    pacienteNuevo.FechaNacimiento = paciente.FechaNacimiento.Value;
                    pacienteNuevo.IdTipoDocumento = paciente.TipoDocumento.IdTipoDocumento;
                    pacienteNuevo.NumeroDocumento = paciente.NumeroDocumento;
                    pacienteNuevo.PrimerApellido = paciente.PrimerApellido;
                    pacienteNuevo.PrimerNombre = paciente.PrimerNombre;
                    pacienteNuevo.SegundoApellido = paciente.SegundoApellido;
                    pacienteNuevo.SegundoNombre = paciente.SegundoNombre;
                    pacienteNuevo.Sexo = paciente.Sexo;
                    contexto.Pacientes.Add(pacienteNuevo);
                }
                else
                {
                    Datos.Paciente pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.IdPaciente == paciente.IdPaciente);
                    if (pacienteActual != null)
                    {
                        pacienteActual.FechaNacimiento = paciente.FechaNacimiento.Value;
                        pacienteActual.IdTipoDocumento = paciente.TipoDocumento.IdTipoDocumento;
                        pacienteActual.NumeroDocumento = paciente.NumeroDocumento;
                        pacienteActual.PrimerApellido = paciente.PrimerApellido;
                        pacienteActual.PrimerNombre = paciente.PrimerNombre;
                        pacienteActual.SegundoApellido = paciente.SegundoApellido;
                        pacienteActual.SegundoNombre = paciente.SegundoNombre;
                        pacienteActual.Sexo = paciente.Sexo;
                    }
                }
                contexto.SaveChanges();
            }
            catch
            {

            }

            var tiposDocumento = contexto.TiposDocumento.OrderBy(t => t.Nombre).Select(t => new TipoDocumento()
            {
                IdTipoDocumento = t.IdTipoDocumento,
                Nombre = t.Nombre
            }).ToList();
            
            ViewBag.TiposDocumento = tiposDocumento.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdTipoDocumento.ToString()
            });

            return View(new Paciente());
        }

        public ActionResult Editar(long id)
        {
            var tiposDocumento = contexto.TiposDocumento.OrderBy(t => t.Nombre).Select(t => new TipoDocumento()
            {
                IdTipoDocumento = t.IdTipoDocumento,
                Nombre = t.Nombre
            }).ToList();

            ViewBag.TiposDocumento = tiposDocumento.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdTipoDocumento.ToString()
            });

            var pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
            Paciente paciente = new Paciente();
            if (pacienteActual != null)
            {
                paciente.IdPaciente = pacienteActual.IdPaciente;
                paciente.FechaNacimiento = pacienteActual.FechaNacimiento;
                paciente.TipoDocumento = new TipoDocumento() { IdTipoDocumento = pacienteActual.IdTipoDocumento };
                paciente.NumeroDocumento = pacienteActual.NumeroDocumento;
                paciente.PrimerApellido = pacienteActual.PrimerApellido;
                paciente.PrimerNombre = pacienteActual.PrimerNombre;
                paciente.SegundoApellido = pacienteActual.SegundoApellido;
                paciente.SegundoNombre = pacienteActual.SegundoNombre;
                paciente.Sexo = pacienteActual.Sexo;
            }

            return View("Crear", paciente);
        }

        public ActionResult Eliminar(long id)
        {
            try
            {
                var pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
                contexto.Pacientes.Remove(pacienteActual);
                contexto.SaveChanges();
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }
    }
}
