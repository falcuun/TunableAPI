using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TunableInterview.Models;
using TunableInterview.SQL;

namespace TunableInterview.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AmountOwedController : Controller
    {

        // https://localhost:44379/AmountOwed
        [HttpGet]
        public ICollection<AmountOwed> totalAmountOwed()
        {
            Dictionary<long, AmountOwed> customersDictionary = new Dictionary<long, AmountOwed>();

            MySqlDataReader rdr = SQLCalls.ExecuteQuery(SQLQueries.Queries["getAllCustomers"]);
            while (rdr.Read())
            {
                long customerID = long.Parse(rdr[0].ToString());
                if (!customersDictionary.ContainsKey(customerID))
                {
                    customersDictionary.Add(customerID, new AmountOwed
                    {
                        customer = new Customer
                        {
                            CustomerId = long.Parse(rdr[0].ToString()),
                            CustomerName = rdr[1].ToString()
                        },
                        amountOwed = int.Parse(rdr[3].ToString()) * int.Parse(rdr[2].ToString())
                    });
                } else
                {
                    customersDictionary[customerID].amountOwed += int.Parse(rdr[3].ToString()) * int.Parse(rdr[2].ToString());
                }
            }
            SQLCalls.CloseConnectionAndReader();
            return customersDictionary.Values;
        }
    }
}
