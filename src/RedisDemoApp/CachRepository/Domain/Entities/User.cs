using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachRepository.Domain.Entities
{
    public class User
    {
        //public enum UserType : byte
        //{
        //    person,
        //    company
        //}
    
        public long Id { get; set; }
        public string Name { get; set; }
        //public string Surname { get; set; }
        public string Email { get; set; }
    }
}
