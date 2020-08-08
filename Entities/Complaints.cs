using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public class Complaints
    {
        public Guid Id { get; set; }

        public string fullName { get; set; }
        public string Description { get; set; }

        public DateTime complaintDate { get; set; }
    }
}
