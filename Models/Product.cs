using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PicknPayAspNetCoreWebApi.Models
{
    public class Product

    {
        public int ProductID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductBrand { get; set; }


        [Column(TypeName = "nvarchar(max)")]
        public string ProductImage { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductCategory { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductPrice { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string ProductPreviousPrice { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string ProductMass { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductBarcode { get; set; }

        [Column(TypeName = "int")]
        public int CartItemCount { get; set; }
    }
}
