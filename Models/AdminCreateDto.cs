using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class AdminCreateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
    }
}
