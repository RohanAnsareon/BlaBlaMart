using BlaBlaMart.Core.Models;
using BlaBlaMart.Core.Abstractions;
using BlaBlaMart.DAL.Repositories;
using System;

using sc = System.Console;

namespace BlaBlaMart.Console {
   public class ProductViewHelpers {
      private readonly IProductRepository repo;

      public ProductViewHelpers(string connStrring) {
         this.repo = new ProductRepository(connStrring);
      }

      public void Menu() {
         sc.WriteLine("Product Menu:");

         sc.WriteLine("Choose an action:");

         sc.WriteLine(
              "1.Create"
          + "\n2.Edit"
          + "\n3.Delete"
          + "\n4.GetById"
          + "\n5.GetAll"
          + "\n6.GetByTitle"
          + "\n7.GetByCost"
          + "\n8.Exit");

         switch (int.Parse(sc.ReadLine())) {
            case 1:
               Create();
               break;
            case 2:
               Edit();
               break;
            case 3:
               Delete();
               break;
            case 4:
               GetById();
               break;
            case 5:
               GetAll();
               break;
            case 6:
               GetByTitle();
               break;
            case 7:
               GetByCost();
               break;
            default:
               sc.WriteLine("Select correct number (1-7)");
               break;
         }

      }

      private void Create() {
         sc.Clear();

         sc.WriteLine("Enter Product params:");

         var product = new Product();

         sc.WriteLine("Enter title:");
         if (string.IsNullOrWhiteSpace(product.Title = sc.ReadLine()))
            throw new Exception("Title cannot be empty");

         sc.WriteLine("Enter cost:");
         if ((product.Cost = decimal.Parse(sc.ReadLine())) < 0)
            throw new Exception("Cost cannot be negative");

         sc.WriteLine("Enter image url:");
         if (string.IsNullOrWhiteSpace(product.ImageUrl = sc.ReadLine()))
            throw new Exception("ImageUrl cannot be empty");

         sc.WriteLine($"Product with {this.repo.Create(product)} id was created");
      }

      private void Edit() {
         sc.Clear();

         int id;

         var product = new Product();

         sc.WriteLine("Enter Id:");
         if ((id = int.Parse(sc.ReadLine())) <= 0)
            throw new Exception("Id cannot be negative or 0");

         sc.WriteLine("Enter title:");
         if (string.IsNullOrWhiteSpace(product.Title = sc.ReadLine()))
            throw new Exception("Title cannot be empty");

         sc.WriteLine("Enter cost:");
         if ((product.Cost = decimal.Parse(sc.ReadLine())) < 0)
            throw new Exception("Cost cannot be negative");

         sc.WriteLine("Enter image url:");
         if (string.IsNullOrWhiteSpace(product.ImageUrl = sc.ReadLine()))
            throw new Exception("ImageUrl cannot be empty");

         this.repo.Edit(id, product);
      }

      private void Delete() {
         sc.Clear();

         int id;

         sc.WriteLine("Enter product Id");
         if ((id = int.Parse(sc.ReadLine())) <= 0)
            throw new Exception("Id cannot be negative or 0");

         this.repo.Delete(id);
      }

      private void GetById() {
         sc.Clear();

         int id;

         sc.WriteLine("Enter product Id");

         if ((id = int.Parse(sc.ReadLine())) <= 0) throw new Exception("Id cannot be negative or 0");

         sc.WriteLine(this.repo.GetProduct(id));
      }

      private void GetAll() {
         sc.Clear();

         foreach (var product in this.repo.GetAllProducts()) {
            sc.WriteLine(product.ToString());
         }
      }

      private void GetByTitle() {

      }

      private void GetByCost() {

      }
   }
}
