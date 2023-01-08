using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class ProductController : Controller
    {
        private static List<ProductViewModel> _productViewModel = new List<ProductViewModel>()
            {
                new ProductViewModel(1,"Susu Kotak", "minuman", 7000),
                new ProductViewModel(2,"Teh Botol", "minuman", 4000),
                new ProductViewModel(3,"Mie Rebus", "makanan", 10000),
                new ProductViewModel(4,"Mie Goreng", "makanan", 12000)
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

            return View(_productViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            _productViewModel.Add(product);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            //Find with Lamda
            ProductViewModel product = _productViewModel.Find(x => x.Id.Equals(id));
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            //hapus data lama
            ProductViewModel productOld = _productViewModel.Find(x => x.Id.Equals(id));
            _productViewModel.Remove(productOld);

            //Input Data Baru
            _productViewModel.Add(product);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            //find with linq
            ProductViewModel product = (
                from p in _productViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new ProductViewModel());
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            //find data
            ProductViewModel product = _productViewModel.Find(x => x.Id.Equals(id));
            //remove data
            _productViewModel.Remove(product);

            return RedirectToAction("List");
        }
    }
}