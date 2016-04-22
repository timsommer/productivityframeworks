using System;
using System.ComponentModel.DataAnnotations;

namespace Wheel.Core
{
    public class Employee   
    {
        [Key]
        public long Id { get; set; }    

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}