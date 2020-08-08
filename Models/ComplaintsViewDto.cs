using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class ComplaintViewDto
    {
        public Guid Id { get; set; }

        public string fullName { get; set; }
        public string Description { get; set; }

        public DateTime complaintDate { get; set; }
    }
}
