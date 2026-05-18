using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FIN_INS.Models
{
   

    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public Invoice Invoice { get; set; }

        [Required]
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public MedicalService MedicalService { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } 
         
        public bool IsVerified { get; set; } = false;
    }
}
