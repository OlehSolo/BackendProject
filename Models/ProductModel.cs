using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPayAspNetCoreWebApi.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductBrand { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductPrice { get; set; }
        public string ProductPreviousPrice { get; set; }
        public string ProductMass { get; set; }
        public string ProductBarcode { get; set; }
        public int CartItemCount { get; set; }
    }
}
