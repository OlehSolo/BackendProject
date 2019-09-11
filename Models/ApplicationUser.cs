using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPayAspNetCoreWebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Mobile { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string StreetAddress { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Suburb { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string PostalCode { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Province { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string IDNumber { get; set; }

    }
}
