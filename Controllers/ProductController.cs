using Microsoft.AspNetCore.Mvc;
using TunableInterview.SQL;

namespace TunableInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        // https://localhost:44379/product/addProduct/name=fan&price=10
        [HttpPost("addProduct/name={productName}&price={productPrice}")]
        public void addProduct(string productName, int productPrice)
        {
            string addProductString = string.Format(SQLQueries.Queries["product"], productName, productPrice);
            SQLCalls.ExecuteNonQuery(addProductString);
        }
    }
}
