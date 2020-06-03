using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public class Drugs
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NafdacNo { get; set; }

        public DateTime ManFactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Guid? manufacturerId { get; set; }

        public DateTime RegisteredDate { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

    }
}
