using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class DrugsViewDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NafdacNo { get; set; }

        public DateTime ManFactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Guid? manufacturerId { get; set; }

        public DateTime RegisteredDate { get; set; }

        public  ManufacturerViewDto Manufacturer { get; set; }
    }
}
