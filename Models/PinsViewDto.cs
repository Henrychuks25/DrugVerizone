using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class PinsViewDto
    {
        public Guid Id { get; set; }

        public string NafDac_Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsInUse { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string verifyPin { get; set; }


        public Admin CreatedByNavigation { get; set; }
    }
}
