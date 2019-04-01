using Model.Models;

namespace Model
{
    public static class Seed
    {
        private static short numberOfRooms = 100;

        public static void SeedInitialData(this DormManagementContext context)
        {
            for (int i = 1; i <= numberOfRooms; i++)
            {
                context.Rooms.Add(new RoomEntity
                {
                    Id = i,
                    Places = 1
                });
            }

            context.SaveChanges();
        }
    }
}
