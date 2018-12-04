using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet("/animal/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/animal")]
        public ActionResult Create(string AnimalName, string AnimalType, string AnimalSex)
        {
            Animal newAnimal = new Animal(AnimalName, AnimalType, AnimalSex);
            newAnimal.Save();
            List<Animal> allAnimals = Animal.GetAll();
            return View("Index", allAnimals);
        }

        [HttpGet("/animal")]
        public ActionResult Index()
        {
            List<Animal> allAnimals = Animal.GetAll();
            return View(allAnimals);
        }

        [HttpGet("/animal/recent")]
        public ActionResult Recent()
        {
            List<Animal> allAnimals = Animal.GetAllSortRecent();
            return View("Index", allAnimals);
        }

        [HttpGet("/animal/{animalId}")]
        public ActionResult Show(int animalId)
        {
            List<Animal> allAnimals = Animal.GetAnimal(animalId);
            return View("Show", allAnimals);
        }

    }
}