using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class ManufacturerViewDto
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string email { get; set; }

        public DateTime RegistrationDate { get; set; }



        public IEnumerable<Drugs> Drugs { get; set; }
    }
}
