using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Entities
{
    public partial class Pins
    {
       
        public Guid Id { get; set; }

        public Guid NafDac_Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInUse { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string verifyPin { get; set; }


        public virtual Admin CreatedByNavigation { get; set; }
    }
}
