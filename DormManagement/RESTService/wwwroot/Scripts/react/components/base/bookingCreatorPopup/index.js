import React from "react";
import Popup from "reactjs-popup";
import DateFilter from "../datefilter";
import Button from "../../base/button";
import BookingsApi from "../../../api/bookings";

export class BookingCreatorPopup extends React.Component {
  constructor() {
    super();

    this.startDate = null;
    this.endDate = null;

    this.state = { error: null };
  }

  createBooking = () => {
    this.setState({ error: null });

    BookingsApi.createBooking(
      this.props.roomId,
      this.startDate,
      this.endDate
    ).then(error => {
      this.setState({ error: error });
      if (!error) {
        this.props.onBookingCreate();
        this.props.onClose();
      }
    });
  };

  render() {
    return (
      <Popup open modal onClose={this.props.onClose} closeOnDocumentClick>
        <h3>Room: {this.props.roomId}</h3>
        <DateFilter
          onChange={(start, end) => {
            this.startDate = start;
            this.endDate = end;
          }}
        />
        <br />
        {this.state.error}
        <br />
        <Button onClick={this.createBooking}>Save</Button>
      </Popup>
    );
  }
}

export default BookingCreatorPopup;
