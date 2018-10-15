using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcEcommerce.Areas.Admin.Models
{
    public class Base
    {
        protected AspNetMvcEcommerceContext _ctx = new AspNetMvcEcommerceContext();
    }
}