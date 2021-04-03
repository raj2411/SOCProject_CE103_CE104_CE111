using SOC_WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOC_WebApplication1.Controllers
{
    public class ProductController : ApiController
    {



        DatabaseContext db = new DatabaseContext();
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }
        [HttpGet]
        public Product GetUser(int id)
        {
            return db.Products.Find(id);    
        }
        [HttpPost]
        public HttpResponseMessage AddProduct(Product model)
        {
            try
            {
                db.Products.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }catch(Exception ex)
            {

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateProduct(int id  , Product model)
        {
            try
            {
                if(id == model.ProductId) { 
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
                }
                else
                {
                    
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;

                }
            }
            catch (Exception ex)
            {

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                return response;
            }
        }

    }
}
