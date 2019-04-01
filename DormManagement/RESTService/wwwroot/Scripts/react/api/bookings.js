export default class BookingsApi {
  static createBooking(roomId, dateFrom, dateTo) {
    return fetch("/booking/create", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ roomId, dateFrom, dateTo })
    }).then(response => {
      switch (response.status) {
        case 200:
          return null;
        case 400:
          return "Date Range already part of a booking for this room.";
        default:
          throw new Error("An error occured!");
      }
    });
  }
}
