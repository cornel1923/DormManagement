using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class RoomEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public short Places { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
