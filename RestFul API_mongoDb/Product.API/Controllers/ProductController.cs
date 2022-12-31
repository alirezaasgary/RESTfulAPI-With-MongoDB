using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Net;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMongoCollection<Product.API.Entities.Product> _productCollection;

        private readonly ILogger<ProductController> _logger;

            public ProductController( ILogger<ProductController> logger, IOptions<ProductDatabaseSettings> productDatabaseSettings)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var mongoClient = new MongoClient(
            productDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productDatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<Entities.Product>(
                productDatabaseSettings.Value.CollectionName);
        }

        [HttpGet]
        public async Task<ActionResult<List<Entities.Product>>> GetAsync()
        {
            return await _productCollection.Find(_ => true).ToListAsync();
        }
     


            
        
    }
}
