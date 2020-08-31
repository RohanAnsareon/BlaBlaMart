using BlaBlaMart.Core.Models;
using BlaBlaMart.DAL.Abstractions;
using BlaBlaMart.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlaBlaMart.Console {
   public class UserViewHelpers {
      private readonly IUserRepository repo;

      public UserViewHelpers(string connString) {
         this.repo = new UserRepository(connString);
      }

      public int Add() {
         var user = new User();
         System.Console.Clear();

         System.Console.WriteLine("Name:");
         if (string.IsNullOrWhiteSpace(user.Name = System.Console.ReadLine()))
            throw new Exception("Name is null or empty");

         System.Console.WriteLine("Age: ");
         if ((user.Age = int.Parse(System.Console.ReadLine())) < 0) 
            throw new Exception("Age cannot be negative number");

         System.Console.WriteLine("Phone: ");
         if (!Regex.IsMatch(user.Phone = System.Console.ReadLine(), "^[+]{1}[0-9]{12}$"))
            throw new Exception("Phone number format is not correct");

         System.Console.WriteLine("Email: ");
         if (!Regex.IsMatch(user.Email = System.Console.ReadLine(), @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            throw new Exception("Email format is not correct");

         System.Console.WriteLine("Address: ");
         if (string.IsNullOrWhiteSpace(user.Address = System.Console.ReadLine()))
            throw new Exception("Address is null or empty");

         System.Console.Clear();

         var id = this.repo.Create(user);

         System.Console.WriteLine($"User with {id} was created");

         return id;
      }

      public void Get() {
         System.Console.Clear();
         System.Console.WriteLine("Enter user id: ");
         var id = int.Parse(System.Console.ReadLine());
         System.Console.Clear();
         System.Console.WriteLine(this.repo.Get(id));
      }

      public void Update() {
         System.Console.Clear();

         System.Console.WriteLine("Enter Id:");
         int id;
         if ((id = int.Parse(System.Console.ReadLine())) < 0)
            throw new Exception("Id cannot be negative");

         var user = new User();

         System.Console.WriteLine("Name:");
         if (string.IsNullOrWhiteSpace(user.Name = System.Console.ReadLine()))
            throw new Exception("Name is null or empty");

         System.Console.WriteLine("Age: ");
         if ((user.Age = int.Parse(System.Console.ReadLine())) < 0)
            throw new Exception("Age cannot be negative number");

         System.Console.WriteLine("Phone: ");
         if (!Regex.IsMatch(user.Phone = System.Console.ReadLine(), "^[+]{1}[0-9]{12}$"))
            throw new Exception("Phone number format is not correct");

         System.Console.WriteLine("Email: ");
         if (!Regex.IsMatch(user.Email = System.Console.ReadLine(), @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            throw new Exception("Email format is not correct");

         System.Console.WriteLine("Address: ");
         if (string.IsNullOrWhiteSpace(user.Address = System.Console.ReadLine()))
            throw new Exception("Address is null or empty");

         this.repo.Edit(id, user);

         System.Console.WriteLine($"User with {id} was successfully updated");
      }

      public void Delete() {
         System.Console.WriteLine("Enter Id for delete User:");

         int id;
         if ((id = int.Parse(System.Console.ReadLine())) < 0)
            throw new Exception("Id cannot be negative");

         this.repo.Delete(id);

         System.Console.WriteLine($"User with {id} id was successfully deleted");
      }
   }
}
