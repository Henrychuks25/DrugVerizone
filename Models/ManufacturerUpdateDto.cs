using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class ManufacturerUpdateDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string email { get; set; }
        public string certificateOfReg { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
