using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ItemReadDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        //public int TodoId { get; set; }
    }
}
