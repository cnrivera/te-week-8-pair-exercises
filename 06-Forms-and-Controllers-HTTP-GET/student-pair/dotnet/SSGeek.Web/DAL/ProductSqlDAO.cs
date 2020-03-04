using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        private string connectionString;

        public ProductSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product productDetail = new Product();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT product_id, name, description, price, image_name FROM products WHERE product_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productDetail = MapRowToProduct(reader);
                }

            }
            return productDetail;
        }

        public IList<Product> GetProducts()
        {
            IList<Product> productList = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT product_id, name, description, price, image_name FROM products", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productList.Add(MapRowToProduct(reader));
                }

            }
            return productList;
        }
        private Product MapRowToProduct(SqlDataReader reader)
        {
            return new Product()
            {
                Id = Convert.ToInt32(reader["product_id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Price = Convert.ToDecimal(reader["price"]),
                ImageName = Convert.ToString(reader["image_name"])
            };
        }

    }

}
