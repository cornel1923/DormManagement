export const parseResponse = response => {
  switch (response.status) {
    case 200:
      return response.json();
    default:
      throw new Error("An error occured!");
  }
};
