using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProgramacionAvanzada.Web.Models;


namespace ProgramacionAvanzada.Web.Controllers
{
    public class JobController : Controller
    {
        private static List<Job> jobs = new List<Job>
        {
            new Job { Id = "1", Name = "Ingeniero", Description = "Diseña sistemas", DateCreated = DateTime.Now },
            new Job { Id = "2", Name = "Doctor", Description = "Atiende pacientes", DateCreated = DateTime.Now },
            new Job { Id = "3", Name = "Abogado", Description = "Asesora legalmente", DateCreated = DateTime.Now },
            new Job { Id = "4", Name = "Arquitecto", Description = "Diseña edificios", DateCreated = DateTime.Now },
            new Job { Id = "5", Name = "Profesor", Description = "Imparte clases", DateCreated = DateTime.Now },
            new Job { Id = "6", Name = "Chef", Description = "Cocina profesionalmente", DateCreated = DateTime.Now },
            new Job { Id = "7", Name = "Mecánico", Description = "Repara vehículos", DateCreated = DateTime.Now },
            new Job { Id = "8", Name = "Enfermero", Description = "Cuida pacientes", DateCreated = DateTime.Now },
            new Job { Id = "9", Name = "Diseñador", Description = "Diseña gráficos", DateCreated = DateTime.Now },
            new Job { Id = "10", Name = "Contador", Description = "Lleva finanzas", DateCreated = DateTime.Now }
        };

        [Route("job/detalle/{id}")]
        public ActionResult Detalle(string id)
        {
            var job = jobs.Find(j => j.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }


        public ActionResult Index()
        {
            return View(jobs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                int newId = jobs.Any() ? jobs.Max(j => int.Parse(j.Id)) + 1 : 1;
                job.Id = newId.ToString();
                job.DateCreated = DateTime.Now;
                jobs.Add(job);
                return RedirectToAction("Index");
            }

            return View(job);
        }

        public ActionResult Edit(string id)
        {
            var job = jobs.Find(j => j.Id == id);
            if (job == null)
                return HttpNotFound();
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                var existingJob = jobs.Find(j => j.Id == job.Id);
                if (existingJob != null)
                {
                    // Actualiza las propiedades del objeto encontrado
                    existingJob.Name = job.Name;
                    existingJob.Description = job.Description;
                    existingJob.DateCreated = job.DateCreated;

                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }

            return View(job);
        }
    }

}