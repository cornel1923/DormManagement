import { parseResponse } from "./utils";

export default class RoomsApi {
  static getRooms() {
    return fetch("/rooms/get", {
      method: "GET"
    }).then(response => parseResponse(response));
  }
}
