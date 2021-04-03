using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplicationMVC.Models;
using System.Text;

namespace WebApplicationMVC.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44344/api");
        // GET: Product
        HttpClient client;
        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<ProductViewModel> modelList = new List<ProductViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/product", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            } 
            return View();
        }
        public ActionResult Edit(int id)
        {
            ProductViewModel model = new ProductViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View("create",model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/product/" + model.ProductId, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("create");
        }

        public ActionResult Details(int id)
        {
            ProductViewModel model = new ProductViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View("create", model);
        }

        [HttpPost]
        public ActionResult Details(ProductViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/product/" ).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("create");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/product/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
    }
}