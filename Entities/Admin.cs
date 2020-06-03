using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid? RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public virtual Roles Role { get; set; }
    }
}
