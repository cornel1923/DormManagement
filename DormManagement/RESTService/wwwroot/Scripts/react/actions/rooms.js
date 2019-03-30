export const types = {
  ROOMS_REQUEST: "ROOMS/ROOMS_GET_REQUEST",
  ROOMS_REQUEST_SUCCESS: "ROOMS/ROOMS_GET_SUCCESS",
  ROOMS_REQUEST_FAILURE: "ROOMS/ROOMS_GET_FAILURE"
};

export const actions = {
  getRooms: () => ({ type: types.ROOMS_REQUEST })
};
