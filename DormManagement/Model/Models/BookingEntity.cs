using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class BookingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        [ForeignKey("Room")]
        public long RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public short UsedPalces { get; set; }

        public short Gender { get; set; }
    }
}
