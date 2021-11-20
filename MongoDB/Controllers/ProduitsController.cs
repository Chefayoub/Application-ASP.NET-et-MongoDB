using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDB.Controllers
{
    public class ProduitsController : Controller
    {
        private ProduitCollection db = new ProduitCollection();

        // GET: Product
        public ActionResult Index()
        {
            var data = db.GetAllProduit();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreationProduit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreationProduit(Produit product)
        {
            db.InsertProduit(product);

            return RedirectToAction("Index", db.GetAllProduit());
        }

        [HttpGet]
        public ActionResult UpdateProduit(string productId)
        {
            var product = db.GetProductById(productId);

            return View("CreateProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateProduit(string productId, Produit product)
        {
            db.UpdateProduit(productId, product);
            var allProduct = db.GetAllProduit();

            return RedirectToAction("Index", allProduct);
        }

        [HttpPost]
        public ActionResult DeleteProduit(string productId)
        {
            db.DeleteContact(productId);

            var all = db.GetAllProduit();
            return RedirectToAction("Index", all);
        }
    }
}