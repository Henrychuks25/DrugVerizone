using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            Admin = new HashSet<Admin>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }


        public virtual ICollection<Admin> Admin { get; set; }
    }
}
