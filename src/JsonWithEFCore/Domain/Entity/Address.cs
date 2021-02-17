using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Address
    {
        //public Address(string city, string bgy, string street)
        //{
        //    City = city;
        //    Bgy = bgy;
        //    Street = street;
        //}

        public string Country { get; set; }
        public string City { get; set; }
        public string Bgy { get; set; }
       // public IList< AddressDetails>  LocalAddress { get; set; }
      
    }
}
