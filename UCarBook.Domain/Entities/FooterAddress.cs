using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCarBook.Domain.Entities
{
    public class FooterAddress
    {
        [Key]
        public int FooterID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
