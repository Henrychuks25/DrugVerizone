using DrugVerizone.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Guid ManufacturerId { get; set; }
        public Guid drugTypeId { get; set; }

        public DateTime RegisteredDate { get; set; }

        [RegularExpression(@"^[A-Za-z][A-Za-z][0-9][0-9]$")]
        [Required]
        [StringLength(6)]
        public string UniqueCode { get; set; }
        public   Manufacturer Manufacturers { get; set; }
        public   DrugTypes DrugType { get; set; }
    }
}
