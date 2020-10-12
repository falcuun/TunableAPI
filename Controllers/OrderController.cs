using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TunableInterview.SQL;

namespace TunableInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        // https://localhost:44379/order/addOrder/customerId=2&productId=2&count=5
        [HttpPost("addOrder/customerId={customerID}&productId={productID}&count={count}")]
        public string addOrder(long customerID, long productID, int count)
        {
            string addOrderString = string.Format(SQLQueries.Queries["order"], customerID, productID, count);
            if (doesCustomerExist(customerID))
            {
                if (doesProductExist(productID))
                {
                    SQLCalls.ExecuteNonQuery(addOrderString);
                    return "Success!";
                }
                else
                {
                    SQLCalls.CloseConnectionAndReader();
                    return "Product Doesn't Exist";
                    //    Debug.WriteLine("Product Doesn't Exist");
                }
            }
            else
            {
                SQLCalls.CloseConnectionAndReader();
                return "Customer Doesn't Exist";
                //    Debug.WriteLine("Customer Doesn't Exist");
            }       
        }
        private bool doesCustomerExist(long customerID)
        {
            string doesCustomerExistString = string.Format(SQLQueries.Queries["doesCustomerExist"], customerID);

            MySqlDataReader rdr = SQLCalls.ExecuteQuery(doesCustomerExistString);

            while (rdr.Read())
            {
            //    Debug.WriteLine(rdr[0].ToString());
                if(rdr[0].ToString().Equals(customerID.ToString()))
                {
                    SQLCalls.CloseConnectionAndReader();
                    return true;
                }
            }
            SQLCalls.CloseConnectionAndReader();
            return false;
        }
        private bool doesProductExist(long productID)
        {
            string doesCustomerExistString = string.Format(SQLQueries.Queries["doesProductExist"], productID);

            MySqlDataReader rdr = SQLCalls.ExecuteQuery(doesCustomerExistString);
            while (rdr.Read())
            {
            //    Debug.WriteLine(rdr[0].ToString());
                if (rdr[0].ToString().Equals(productID.ToString()))
                {
                    SQLCalls.CloseConnectionAndReader();
                    return true;
                }
            }
            SQLCalls.CloseConnectionAndReader();
            return false;
        }


    }

}
