using BlaBlaMart.Core.Models;
using BlaBlaMart.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlaBlaMart.DAL.Repositories {
   public class UserRepository : IUserRepository {
      private readonly string connString;

      public UserRepository(string connString) {
         this.connString = connString;
      }

      public int Create(User user) {
         throw new NotImplementedException();
      }

      public void Delete(int id) {
         throw new NotImplementedException();
      }

      public void Edit(int id, User user) {
         throw new NotImplementedException();
      }

      public User Get(int id) {
         throw new NotImplementedException();
      }
   }
}
