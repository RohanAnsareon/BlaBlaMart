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

      public void Create(Product product) {
         
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
                        ,[Weight] = @Weight
                   WHERE Id = @Id";

         using (var connection = new SqlConnection(connString)) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {
               command.Parameters.AddWithValue("@Id", id);
               command.Parameters.AddWithValue("@Title", product.Title);
               command.Parameters.AddWithValue("@Cost", product.Cost);
               command.Parameters.AddWithValue("@Weight", product.);

               if (command.ExecuteNonQuery() == 0)
                  throw new Exception("User was not edited");
            }
         }
      }

      public Product[] GetAllProducts() {
         throw new NotImplementedException();
      }

      public Product GetProduct(int id) {
         throw new NotImplementedException();
      }

      public Product[] GetProductsByCost(decimal min, decimal max) {
         throw new NotImplementedException();
      }

      public Product[] GetProductsByTitle(string title) {
         throw new NotImplementedException();
      }
   }
}
