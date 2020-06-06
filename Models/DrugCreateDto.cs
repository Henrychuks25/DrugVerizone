using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class DrugCreateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NafdacNo { get; set; }

        public DateTime ManFactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public DateTime RegisteredDate { get; set; }

    }
}
