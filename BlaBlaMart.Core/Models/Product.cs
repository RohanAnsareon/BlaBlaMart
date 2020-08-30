using System;
using System.Collections.Generic;
using System.Text;

namespace BlaBlaMart.Core.Models {
   public class Product {
      public int Id { get; set; }
      public string Title { get; set; }
      public decimal Cost { get; set; }
      public string ImageUrl { get; set; }
   }
}
