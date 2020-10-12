using System.Collections.Generic;

namespace TunableInterview.SQL
{
    public static class SQLQueries
    {
        public static Dictionary<string, string> Queries = new Dictionary<string, string>();

        public static void CreateQueries()
        {
            Queries.Add("customer", "INSERT INTO `tunabledb`.`customers`(customer_name) VALUES('{0}');");
            Queries.Add("product", "INSERT INTO `tunabledb`.`products`(product_name, product_price) VALUES('{0}', '{1}'); ");
            Queries.Add("order", "INSERT INTO `tunabledb`.`orders`(customer_id, product_id, count) VALUES({0}, {1}, {2});");
            Queries.Add("doesCustomerExist", "SELECT customer_id FROM customers WHERE customer_id = {0}");
            Queries.Add("doesProductExist", "SELECT product_id FROM products WHERE product_id = {0}");
            Queries.Add("showTables", "SHOW TABLES");
            Queries.Add("getAllCustomers", "SELECT c.customer_id, c.customer_name, p.product_price, o.count FROM customers c INNER JOIN orders o ON o.customer_id = c.customer_id INNER JOIN products p ON p.product_id = o.product_id;");
            Queries.Add("createTables", "CREATE TABLE `tunabledb`.`customers` (`customer_id` INT(10) NOT NULL AUTO_INCREMENT ,`customer_name` VARCHAR(255) NOT NULL ,PRIMARY KEY (`customer_id`));CREATE TABLE `tunabledb`.`products` (`product_id` INT(10) NOT NULL AUTO_INCREMENT ,`product_name` VARCHAR(255) NOT NULL ,`product_price` INT(4) NOT NULL ,PRIMARY KEY (`product_id`));CREATE TABLE `tunabledb`.`orders` (`order_id` INT(10) NOT NULL AUTO_INCREMENT,`customer_id` INT(10) NOT NULL,`product_id` INT(10) NOT NULL,`count` INT(4) NOT NULL,PRIMARY KEY (`order_id`),FOREIGN KEY (customer_id) REFERENCES `tunabledb`.`customers`(customer_id),FOREIGN KEY (product_id) REFERENCES `tunabledb`.`products`(product_id))ENGINE = InnoDB;");
        }
    }
}
