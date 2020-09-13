using Microsoft.Extensions.Configuration;
using System;

using sc = System.Console;

namespace BlaBlaMart.Console {
   class Program {
      public static IConfiguration configuration;

      static void Main(string[] args) {
         configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

         var connectionString = configuration.GetConnectionString("BlaBlaDB");

         var userInterface = new UserViewHelpers(connectionString);

         var productInterface = new ProductViewHelpers(connectionString);

         productInterface.Menu();

         sc.ReadLine();
      }
   }
}
