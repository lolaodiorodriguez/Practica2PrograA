using ProgramacionAvanzada.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProgramacionAvanzada.Web.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person> persons = new List<Person>
        {
            new Person { Id = 1, Name = "Ana", Description = "Ingeniera de software", DateCreated = DateTime.Now },
            new Person { Id = 2, Name = "Luis", Description = "Analista de datos", DateCreated = DateTime.Now },
            new Person { Id = 3, Name = "Carlos", Description = "Desarrollador", DateCreated = DateTime.Now },
            new Person { Id = 4, Name = "Elena", Description = "Tester QA", DateCreated = DateTime.Now },
            new Person { Id = 5, Name = "María", Description = "Project Manager", DateCreated = DateTime.Now },
            new Person { Id = 6, Name = "José", Description = "Soporte técnico", DateCreated = DateTime.Now },
            new Person { Id = 7, Name = "Laura", Description = "UX Designer", DateCreated = DateTime.Now },
            new Person { Id = 8, Name = "Tomás", Description = "Administrador de BD", DateCreated = DateTime.Now },
            new Person { Id = 9, Name = "Rosa", Description = "Arquitecta de Software", DateCreated = DateTime.Now },
            new Person { Id = 10, Name = "Pedro", Description = "Ingeniero DevOps", DateCreated = DateTime.Now }
     };

        public ActionResult Index()
        {
            return View(persons);
        }

        [Route("person/detalle/{id}")]
        public ActionResult Detalle(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            return View(person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = persons.Any() ? persons.Max(p => p.Id) + 1 : 1;
                if (person.DateCreated == DateTime.MinValue)
                {
                    person.DateCreated = DateTime.Now;
                }

                persons.Add(person);
                return View("Index", persons);
            }

            return View(person);
        }
    }
}