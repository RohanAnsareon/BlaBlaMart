using BlaBlaMart.Core.Models;
using BlaBlaMart.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BlaBlaMart.DAL.Repositories {
   public class ProductRepository : IProductRepository {
      private readonly string connString;

      public ProductRepository(string connString) {
         this.connString = connString;
      }

      public int Create(Product product) {
         var sql = @"INSERT INTO [dbo].[Product]
                          ([Title]
                          ,[Cost]
                          ,[ImageUrl])
                    VALUES
                          (@Title
                          ,@Cost
                          ,@ImageUrl);
                     SET @id=SCOPE_IDENTITY()";

         using (var connection = new SqlConnection(this.connString)) {
            connection.Open();
            using (var command = new SqlCommand(sql, connection)) {
               command.Parameters.AddWithValue("@Title", product.Title);
               command.Parameters.AddWithValue("@Cost", product.Cost);
               command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);

               var idParam = new SqlParameter {
                  ParameterName = "@id",
                  SqlDbType = System.Data.SqlDbType.Int,
                  Direction = System.Data.ParameterDirection.Output
               };

               command.Parameters.Add(idParam);

               if (command.ExecuteNonQuery() == 0)
                  throw new Exception("Product was not inserted");
               else
                  return Convert.ToInt32(idParam.Value);
            }
         }
      }

      public void Delete(int id) {
         var sql = @"DELETE FROM [dbo].[Product]
                     WHERE Id = @Id";

         using (var connection = new SqlConnection(connString)) {
            connection.Open();
            using (var cmd = new SqlCommand(sql, connection)) {
               cmd.Parameters.AddWithValue("@Id", id);
               if (cmd.ExecuteNonQuery() == 0)
                  throw new Exception($"Product with {id} id was not deleted");
            }
         }
      }

      public void Edit(int id, Product product) {
         var sql = @"UPDATE [dbo].[Product]
                     SET [Title] = @Title
                        ,[Cost] = @Cost
                        ,[ImageUrl] = @ImageUrl
                   WHERE Id = @Id";

         using (var connection = new SqlConnection(connString)) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {
               command.Parameters.AddWithValue("@Id", id);
               command.Parameters.AddWithValue("@Title", product.Title);
               command.Parameters.AddWithValue("@Cost", product.Cost);
               command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);

               if (command.ExecuteNonQuery() == 0)
                  throw new Exception("User was not edited");
            }
         }
      }

      public Product[] GetAllProducts() {
         var sql = @"SELECT * FROM [BlaBlaMartDb].[dbo].[Product]";

         using (var connection = new SqlConnection(this.connString)) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {


               using (var reader = command.ExecuteReader()) {

                  var products = new List<Product>();

                  while (reader.Read()) {
                     products.Add(new Product {
                        Id = Convert.ToInt32(reader["Id"]),
                        Cost = Convert.ToDecimal(reader["Cost"]),
                        ImageUrl = reader["ImageUrl"].ToString(),
                        Title = reader["Title"].ToString()
                     });
                  }

                  return products.ToArray();
               }
            }
         }
      }

      public Product GetProduct(int id) {
         var sql = @"SELECT * FROM [BlaBlaMartDb].[dbo].[Product] WHERE Id = @Id";

         using (var connection = new SqlConnection()) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {

               command.Parameters.AddWithValue("@Id", id);

               using (var reader = command.ExecuteReader()) {
                  reader.Read();
                  return new Product {
                     Id = Convert.ToInt32(reader["Id"]),
                     Cost = Convert.ToDecimal(reader["Cost"]),
                     ImageUrl = reader["ImageUrl"].ToString(),
                     Title = reader["Title"].ToString()
                  };
               }
            }
         }
      }

      public Product[] GetProductsByCost(decimal min, decimal max) {
         throw new NotImplementedException();
      }

      public Product[] GetProductsByTitle(string title) {
         throw new NotImplementedException();
      }
   }
}