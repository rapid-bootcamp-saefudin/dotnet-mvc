using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class DivisionController : Controller
    {
        private static List<DivisionViewModel> _divisionViewModel = new List<DivisionViewModel>()
            {
                new DivisionViewModel(
                    1,
                    "Sales Manager"
                ),
                new DivisionViewModel(
                    2,
                    "Sales Leader"
                ),
                new DivisionViewModel(
                    3,
                    "Senior Staff"
                ),
                new DivisionViewModel(
                    4,
                    "Assistant"
                ),
                new DivisionViewModel(
                    5,
                    "Junior Staff"
                ),
                new DivisionViewModel(
                    6,
                    "Leadership Intern"
                ),
                new DivisionViewModel(
                    7,
                    "Intern"
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

            return View(_divisionViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, DivisionName")] DivisionViewModel division)
        {
            _divisionViewModel.Add(division);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            DivisionViewModel division = _divisionViewModel.Find(x => x.Id.Equals(id));
            return View(division);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, DivisionName")] DivisionViewModel division)
        {
            DivisionViewModel divisionOld = _divisionViewModel.Find(x => x.Id.Equals(id));
            _divisionViewModel.Remove(divisionOld);

            _divisionViewModel.Add(division);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            DivisionViewModel division = (
                from p in _divisionViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new DivisionViewModel());
            return View(division);
        }

        public IActionResult Delete(int? id)
        {
            DivisionViewModel division = _divisionViewModel.Find(x => x.Id.Equals(id));
            _divisionViewModel.Remove(division);

            return RedirectToAction("List");
        }
    }
}