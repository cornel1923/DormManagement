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

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
