export const mappRooms = rooms =>
  rooms.map(room => ({
    id: room.Id,
    places: room.Places
  }));
