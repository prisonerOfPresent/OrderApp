using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OrderApp.Data.Entities
{
    public partial class Business
    {
        public Business()
        {
            Location = new HashSet<Location>();
            Product = new HashSet<Product>();
        }

        public int ID { get; set; }
        public string BusinessID { get; set; }
        public string Name { get; set; }
        public long CreatedDate { get; set; }
        public long ModifiedDate { get; set; }
        public string Meta { get; set; }

        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
