import { call, put } from "redux-saga/effects";
import { mappRooms } from "./mappers";
import { types as roomsActionTypes } from "../actions/rooms";
import RoomsApi from "../api/rooms";

export function* getRooms(action) {
  try {
    const data = yield call(RoomsApi.getRooms, action.start, action.end);

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
