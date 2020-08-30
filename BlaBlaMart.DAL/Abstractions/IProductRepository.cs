using BlaBlaMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlaBlaMart.DAL.Abstractions {
   public interface IProductRepository {
      void Create(Product product);
      Product GetProduct(int id);
      Product[] GetAllProducts();
      Product[] GetProductsByCost(decimal min, decimal max);
      Product[] GetProductsByTitle(string title);
      void Edit(int id, Product product);
      void Delete(int id);
   }
}
