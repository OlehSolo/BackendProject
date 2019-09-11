using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPayAspNetCoreWebApi.Models
{
    public class ApplicationSettings
    {
        public string Jwt_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
