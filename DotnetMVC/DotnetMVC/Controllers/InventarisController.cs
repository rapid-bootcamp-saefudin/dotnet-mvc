using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class InventarisController : Controller
    {
        private static List<InventarisViewModel> _InventarisViewModel = new List<InventarisViewModel>()
            {
                new InventarisViewModel(
                    1,
                    "Lenovo Yoga Slim 7i Pro",
                    "Laptop",
                    "Lenovo",
                    120
                ),
                new InventarisViewModel(
                    2,
                    "Lenovo ThinkPad X1 Yoga",
                    "Laptop",
                    "Lenovo",
                    95
                ),
                new InventarisViewModel(
                    3,
                    "Apple iPad Pro (Gen 3)",
                    "Tablet PC",
                    "Apple",
                    60
                ),
                new InventarisViewModel(
                    4,
                    "Supra X 125 FI",
                    "Motorcycle",
                    "Honda",
                    50
                ),
                new InventarisViewModel(
                    5,
                    "CRF150L",
                    "Motorcycle",
                    "Honda",
                    30
                ),
                new InventarisViewModel(
                    6,
                    "New Rush GR Sport",
                    "Car",
                    "Toyota",
                    20
                ),
                new InventarisViewModel(
                    7,
                    "New Kijang Innova Zenix G",
                    "Car",
                    "Toyota",
                    15
                ),
                new InventarisViewModel(
                    8,
                    "New Fortuner GR Sport",
                    "Car",
                    "Toyota",
                    6
                ),
            };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {

            return View(_InventarisViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, ProductName, Category, Brand, Stock")] InventarisViewModel Inventaris)
        {
            _InventarisViewModel.Add(Inventaris);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            InventarisViewModel Inventaris = _InventarisViewModel.Find(x => x.Id.Equals(id));
            return View(Inventaris);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, ProductName, Category, Brand, Stock")] InventarisViewModel Inventaris)
        {
            InventarisViewModel InventarisOld = _InventarisViewModel.Find(x => x.Id.Equals(id));
            _InventarisViewModel.Remove(InventarisOld);

            _InventarisViewModel.Add(Inventaris);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            InventarisViewModel Inventaris = (
                from p in _InventarisViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new InventarisViewModel());
            return View(Inventaris);
        }

        public IActionResult Delete(int? id)
        {
            InventarisViewModel Inventaris = _InventarisViewModel.Find(x => x.Id.Equals(id));
            _InventarisViewModel.Remove(Inventaris);

            return RedirectToAction("List");
        }
    }
}