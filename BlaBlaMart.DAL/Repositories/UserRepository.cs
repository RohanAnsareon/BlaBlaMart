using BlaBlaMart.Core.Abstractions;
using BlaBlaMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BlaBlaMart.DAL.Repositories {
   public class UserRepository : IUserRepository {
      private readonly string connString;

      public UserRepository(string connString) {
         this.connString = connString;
      }

      public int Create(User user) {
         var sql = @"INSERT INTO [dbo].[User]
                                ([Name]
                                ,[Age]
                                ,[Email]
                                ,[Phone]
                                ,[Address])
                          VALUES
                                (@Name
                                ,@Age
                                ,@Email
                                ,@Phone
                                ,@Address;
                     SET @id=SCOPE_IDENTITY()";

         using (var connection = new SqlConnection(this.connString)) {
            connection.Open();
            using (var cmd = new SqlCommand(sql, connection)) {
               cmd.Parameters.AddWithValue("@Name", user.Name);
               cmd.Parameters.AddWithValue("@Age", user.Age);
               cmd.Parameters.AddWithValue("@Email", user.Email);
               cmd.Parameters.AddWithValue("@Phone", user.Phone);
               cmd.Parameters.AddWithValue("@Address", user.Address);

               var idParam = new SqlParameter
               {
                  ParameterName = "@id",
                  SqlDbType = System.Data.SqlDbType.Int,
                  Direction = System.Data.ParameterDirection.Output
               };

               cmd.Parameters.Add(idParam);

               if (cmd.ExecuteNonQuery() == 0)
                  throw new Exception("User was not inserted");
               else
                  return Convert.ToInt32(idParam.Value);
            }
         }
      }

      public void Delete(int id) {
         var sql = @"DELETE FROM [dbo].[User]
                     WHERE Id = @Id";

         using (var connection = new SqlConnection(connString)) {
            connection.Open();
            using (var cmd = new SqlCommand(sql, connection)) {
               cmd.Parameters.AddWithValue("@Id", id);
               if (cmd.ExecuteNonQuery() == 0)
                  throw new Exception($"User with {id} id was not deleted");
            }
         }
      }

      public void Edit(int id, User user) {
         var sql = @"UPDATE [dbo].[User]
                     SET [Name] = @Name
                        ,[Age] = @Age
                        ,[Email] = @Email
                        ,[Phone] = @Phone
                        ,[Address] = @Address
                   WHERE Id = @Id";

         using (var connection = new SqlConnection(connString)) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {
               command.Parameters.AddWithValue("@Id", id);
               command.Parameters.AddWithValue("@Name", user.Name);
               command.Parameters.AddWithValue("@Age", user.Age);
               command.Parameters.AddWithValue("@Email", user.Email);
               command.Parameters.AddWithValue("@Phone", user.Phone);
               command.Parameters.AddWithValue("@Address", user.Address);

               if (command.ExecuteNonQuery() == 0)
                  throw new Exception("User was not edited");
            }
         }
      }

      public User Get(int id) {
         var sql = @"SELECT * FROM [dbo].[User] WHERE Id = @Id";

         using (var connection = new SqlConnection(this.connString)) {
            connection.Open();

            using (var command = new SqlCommand(sql, connection)) {
               command.Parameters.AddWithValue("@Id", id);

               using (var reader = command.ExecuteReader()) {
                  if (!reader.Read()) throw new Exception("There are no rows");

                  return new User
                  {
                     Id = Convert.ToInt32(reader["Id"]),
                     Name = reader["Name"].ToString(),
                     Age = Convert.ToInt32(reader["Age"]),
                     Email = reader["Email"].ToString(),
                     Phone = reader["Phone"].ToString(),
                     Address = reader["Address"].ToString()
                  };
               }
            }
         }
      }
   }
}
