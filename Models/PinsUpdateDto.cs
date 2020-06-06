using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class PinsUpdateDto
    {
        public bool IsActive { get; set; }
        public bool IsInUse { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
