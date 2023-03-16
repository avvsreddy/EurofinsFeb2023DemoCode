using CrezyProductsCatalogService.Models.Data;
using CrezyProductsCatalogService.Models.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrezyProductsCatalogService.Controllers
{

    public class CrezyProductsController : ApiController
    {
        private CrezyProductsDbContext db = new CrezyProductsDbContext();

        // Design and implement the end-points
        // URI
        // Resource : Products
        // Action: GET
        // URI: GET .../api/CrezyProdcuts
        //[HttpGet]
        public List<CrezyProduct> GetProducts()
        {
            // get the products from back-end
            return db.CrezyProducts.ToList();
            // return the products
        }
        // GET .../api/crezyproduts/1
        public IHttpActionResult GetCrezyProduct(int id)
        {
            var product = db.CrezyProducts.Find(id);
            if (product == null)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(product);
        }
        // GET .../api/crezyproducts/category/mobiles
        [Route("api/crezyproducts/category/{category}")]
        //[HttpGet]
        public IHttpActionResult GetCrezyProductsByCategory(string category)
        {
            var products = db.CrezyProducts.Where(p => p.Catagory == category).ToList();
            if (products == null || products.Count == 0)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(products);
        }


        // return all products based on country
        // return all products based on brand
        // return expensive product
        // return cheapest product
        // return all products between min price and max price range
        // return product based on name

    }
}
