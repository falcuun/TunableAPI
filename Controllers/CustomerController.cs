using Microsoft.AspNetCore.Mvc;
using TunableInterview.SQL;

namespace TunableInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // https://localhost:44379/customer/addCustomer/name=Barack&lastName=Obama
        [HttpPost("addCustomer/name={customerFirstName}&lastName={customerLastName}")]
        public void addCustomer(string customerFirstName, string customerLastName)
        {
            string customerName = customerFirstName.Trim() + " " + customerLastName.Trim();
            string addCustomerString = string.Format(SQLQueries.Queries["customer"], customerName);
            SQLCalls.ExecuteNonQuery(addCustomerString);
        }
    }
}
