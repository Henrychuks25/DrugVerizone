using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public class Manufacturer
    {

        public Manufacturer()
        {
            Drugs = new HashSet<Drugs>();
        }
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string email { get; set; }
        public string certificateOfReg { get; set; }

        public DateTime RegistrationDate { get; set; }


       

        public virtual ICollection<Drugs> Drugs { get; set; }
    }
}
