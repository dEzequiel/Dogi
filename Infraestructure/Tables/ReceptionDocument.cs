using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Tables
{
    [Table("ReceptionDocument", Schema = "dbo")]
    public class ReceptionDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid Category { get; private set; }
        public int Sex { get; private set; }
        public bool HasChip { get; private set; } 
        public string Color { get; private set; } 
        public string? Observations { get; private set; } 
        public string? PickupLocation { get; private set; } 
        public DateTime? PickupDate { get; private set; }
    }
}
