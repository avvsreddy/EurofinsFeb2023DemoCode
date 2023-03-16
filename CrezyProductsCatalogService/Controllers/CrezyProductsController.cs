using CrezyProductsCatalogService.Models.Data;
using CrezyProductsCatalogService.Models.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

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
        [Route("api/crezyproducts/country/{country}")]
        public IHttpActionResult GetCrezyProductsByCountry(string country)
        {
            var products = db.CrezyProducts.Where(p => p.Country == country).ToList();
            if (products == null || products.Count == 0)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(products);
        }
        // return all products based on brand
        [Route("api/crezyproducts/brand/{brand}")]
        public IHttpActionResult GetCrezyProductsByBrand(string brand)
        {
            var products = db.CrezyProducts.Where(p => p.Brand == brand).ToList();
            if (products == null || products.Count == 0)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(products);
        }
        // return expensive product
        [Route("api/crezyproducts/expensive")]
        public IHttpActionResult GetExpensiveProduct()
        {
            return Ok(db.CrezyProducts.OrderByDescending(p => p.Price).FirstOrDefault());
        }
        // return cheapest product
        [Route("api/crezyproducts/cheapest")]
        public IHttpActionResult GetCheapestProduct()
        {
            return Ok(db.CrezyProducts.OrderBy(p => p.Price).FirstOrDefault());
        }
        // return all products between min price and max price range
        [Route("api/crezyproducts/price/min/{min}/max/{max}")]
        public IHttpActionResult GetProductsByPriceRange(int min, int max)
        {
            var products = db.CrezyProducts.Where(p => p.Price >= min && p.Price <= max).ToList();
            if (products == null || products.Count == 0)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(products);
        }
        // return product based on name
        [Route("api/crezyproducts/name/{name}")]
        public IHttpActionResult GetCrezyProductsByName(string name)
        {
            var products = db.CrezyProducts.Where(p => p.Name == name).ToList();
            if (products == null || products.Count == 0)  // not found
            {
                // return status code 404
                return NotFound();
            }
            // if found return data + status code 200
            return Ok(products);
        }
    }
}
