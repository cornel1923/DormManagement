import { parseResponse } from "./utils";

export default class RoomsApi {
  static getRooms(start, end) {
    return fetch(`/room/get?dateFrom=${start}&dateTo=${end} `, {
      method: "GET"
    }).then(response => parseResponse(response));
  }
}
