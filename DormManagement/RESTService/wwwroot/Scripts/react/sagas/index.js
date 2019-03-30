import { fork, takeLatest, all } from "redux-saga/effects";

import { types as roomsActionTypes } from "../actions/rooms";

import { getRooms } from "./rooms";

export default function* sagas() {
  yield all([fork(takeLatest, roomsActionTypes.ROOMS_REQUEST, getRooms)]);
}
