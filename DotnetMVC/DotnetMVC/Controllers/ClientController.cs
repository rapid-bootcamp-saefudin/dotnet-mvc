using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class ClientController : Controller
    {
        private static List<ClientViewModel> _clientViewModel = new List<ClientViewModel>()
            {
                new ClientViewModel(
                    1,
                    "Apud",
                    "apud@honda.sample",
                    "Man",
                    "Honda Asta"
                ),
                new ClientViewModel(
                    2,
                    "Jane",
                    "jane@toyota.sample",
                    "Woman",
                    "Toyota Astra"
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

            return View(_clientViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, ClientName, ClientEmail, Gender, CompanyName")] ClientViewModel client)
        {
            _clientViewModel.Add(client);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            ClientViewModel client = _clientViewModel.Find(x => x.Id.Equals(id));
            return View(client);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, ClientName, ClientEmail, Gender, CompanyName")] ClientViewModel client)
        {
            ClientViewModel clientOld = _clientViewModel.Find(x => x.Id.Equals(id));
            _clientViewModel.Remove(clientOld);

            _clientViewModel.Add(client);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            ClientViewModel client = (
                from p in _clientViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new ClientViewModel());
            return View(client);
        }

        public IActionResult Delete(int? id)
        {
            ClientViewModel client = _clientViewModel.Find(x => x.Id.Equals(id));
            _clientViewModel.Remove(client);

            return RedirectToAction("List");
        }
    }
}