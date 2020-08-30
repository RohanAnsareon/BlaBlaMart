using Microsoft.Extensions.Configuration;
using System;

namespace BlaBlaMart.Console {
   class Program {
      public static IConfiguration configuration;

      static void Main(string[] args) {
         configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

      }
   }
}
