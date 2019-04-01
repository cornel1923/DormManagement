using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model
{
    public class DormManagementContext : DbContext
    {
        public DormManagementContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DormManagementContext()
        {

        }

        public virtual DbSet<RoomEntity> Rooms { get; set; }

        public virtual DbSet<BookingEntity> Bookings { get; set; }
    }
}
