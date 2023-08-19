using CrudOperationUsingMVc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationUsingMVc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        static List<Product> list = new List<Product>()
        {


            new Product(){productId=1,productName="Test",productDescription="Test",productCategory="Test",productPrice=11},
			new Product(){productId=2,productName="Test",productDescription="Test",productCategory="Test",productPrice=11},
			new Product(){productId=3,productName="Test",productDescription="Test",productCategory="Test",productPrice=11},
			new Product(){productId=4,productName="Test",productDescription="Test",productCategory="Test",productPrice=11}
		};
        public ActionResult Index()
        {
            return View(list);
        }

		/* ..........Create functionality.......*/
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
        [HttpPost]
		public ActionResult Create(Product pr)
		{
            list.Add(pr);
			ViewBag.Message = "Data Insert Successfully";
			return RedirectToAction("Index");
		}

        /* ..........Edit functionality.......*/

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result= list.FirstOrDefault(m=>m.productId==id);   


            return View(result);
        }
        [HttpPost]
		public ActionResult Edit(Product model)
		{
			var result = list.FirstOrDefault(m => m.productId == model.productId);

            if(result != null)
            {
                result.productName = model.productName;
                result.productDescription = model.productDescription;
                        result.productCategory = model.productCategory;
                    result.productPrice = model.productPrice;
                
            }
            return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			var result = list.FindAll(m => m.productId == id).FirstOrDefault();

			return View(result);
		}
		[HttpGet]
        public ActionResult Delete(int id)
        {
			var data = list.Where(x => x.productId == id).FirstOrDefault();
				list.Remove(data);
				
				ViewBag.Messsage = "Record Delete Successfully";
				return RedirectToAction("index");
		
		}

       
	}
       
}