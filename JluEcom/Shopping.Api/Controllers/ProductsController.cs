using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Api.Models;
using System.Collections.Generic;
using Shopping.Api.Data;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly ProductContext productContext;

        public ProductsController(ILogger<ProductsController> logger, ProductContext productContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await productContext.Products.Find(productContext => true).ToListAsync();
        }
    }
}
