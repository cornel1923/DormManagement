import { call, put } from "redux-saga/effects";
import { mappRooms } from "./mappers";
import { types as roomsActionTypes } from "../actions/rooms";
import RoomsApi from "../api/rooms";

export function* getRooms() {
  try {
    const data = yield call(RoomsApi.getRooms);
    const rooms = mappRooms(data);

    yield put({
      type: roomsActionTypes.ROOMS_REQUEST_SUCCESS,
      rooms
    });
  } catch (error) {
    yield put({
      type: roomsActionTypes.ROOMS_REQUEST_FAILURE,
      error
    });
  }
}
