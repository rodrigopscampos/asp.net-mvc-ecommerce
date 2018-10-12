using System;
using System.Collections.Generic;

namespace ElectricsOnlineWebApp
{
    public class Customer
    {
        public int Id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Ctype { get; set; }
        public string CardNo { get; set; }
        public DateTime ExpDate { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}