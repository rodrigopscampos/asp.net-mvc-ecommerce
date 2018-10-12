using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricsOnlineWebApp.Areas.Admin.Models
{
    public class Base
    {
        protected DbStoreContext _ctx = new DbStoreContext();
    }
}