using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return await _ProductService.GetAllProduct();
        }
    }
}