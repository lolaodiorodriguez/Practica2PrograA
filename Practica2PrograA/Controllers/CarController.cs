using Newtonsoft.Json;
using ProgramacionAvanzada.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramacionAvanzada.Web.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id_Car = 1, Name = "Tesla Model X", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 2, Name = "Tesla Model Y", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 3, Name = "Tesla Model E", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 4, Name = "Tesla Model S", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 5, Name = " Tesla Cybertruck", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 6, Name = "Tesla 3", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 7, Name = "BMW i5", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 8, Name = "BMW i7", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 9, Name = "BMW i4", Description = "Eléctrico", Data_Created = DateTime.Now },
            new Car { Id_Car = 10, Name = "BMW iXM", Description = "100% Eléctrico", Data_Created = DateTime.Now }
        };

        
        [Route("car/detalle/{Id_Car:int}")]
        public ActionResult Detalle(int Id_Car)
        {
            var car = cars.Find(c => c.Id_Car == Id_Car);
            return View(car);
        }

        public ActionResult Index()
        {
            return View(cars);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {

                car.Id_Car = cars.Any() ? cars.Max(c => c.Id_Car) + 1 : 1;
                if (car.Data_Created == DateTime.MinValue)
                {
                    car.Data_Created = DateTime.Now;
                }


                cars.Add(car);

                
                return RedirectToAction("Index");
            }

            return View(cars);
        }
    }
}