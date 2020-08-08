using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Models
{
    public class DrugCreateDto
    {
        public Guid Id { get; set; }
        public Guid manufacturerId { get; set; }
        public Guid drugTypeId { get; set; }

        public string Name { get; set; }

        public string NafdacNo { get; set; }

        public DateTime ManFactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        //[RegularExpression(@"^[A-Za-z][A-Za-z][0-9][0-9]$")]
        [Required]
        [StringLength(6)]
        public string UniqueCode { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
}
