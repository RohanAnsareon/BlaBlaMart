using BlaBlaMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlaBlaMart.DAL.Abstractions {
   public interface IUserRepository {
      int Create(User user);
      User Get(int id);
      void Edit(int id, User user);
      void Delete(int id);
   }
}
