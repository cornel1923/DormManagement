using Model.Models;

namespace Model
{
    public static class Seed
    {
        public static void SeedInitialData(this DormManagementContext context)
        {
            context.Rooms.Add(new RoomEntity
            {
                RoomId = 1,
            });

            context.SaveChanges();
        }
    }
}
