import { types as roomsActionTypes } from "../actions/rooms";

export const initialState = {
  rooms: [],
  isLoading: true,
  error: null,
  lastFetch: null
};

export const rooms = (state = initialState, action) => {
  switch (action.type) {
    case roomsActionTypes.ROOMS_REQUEST:
      return {
        ...state,
        isLoading: true,
        error: null,
        rooms: []
      };
    case roomsActionTypes.ROOMS_REQUEST_SUCCESS:
      return {
        ...state,
        isLoading: false,
        rooms: action.rooms,
        lastFetch: Date.now()
      };
    case roomsActionTypes.ROOMS_REQUEST_FAILURE:
      return { ...state, isLoading: false, error: "An error occured" };

    default:
      return state;
  }
};
