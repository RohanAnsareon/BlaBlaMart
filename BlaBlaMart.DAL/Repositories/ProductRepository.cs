using BlaBlaMart.Core.Models;
using BlaBlaMart.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlaBlaMart.DAL.Repositories {
   public class ProductRepository : IProductRepository {
      public void Create(Product product) {
         throw new NotImplementedException();
      }

      public void Delete(int id) {
         throw new NotImplementedException();
      }

      public void Edit(int id, Product product) {
         throw new NotImplementedException();
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
