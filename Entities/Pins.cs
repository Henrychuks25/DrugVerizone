using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public class Pins
    {
        public Guid Id { get; set; }

        public Guid NafDac_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string verifyPin { get; set; }
    }
}
