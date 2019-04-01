import React, { Component } from "react";
import PropTypes from "prop-types";
import Table from "../base/table";
import Button from "../base/button";
import BookingCreatorPopup from "../base/bookingCreatorPopup";

export default class RoomsTable extends Component {
  constructor() {
    super();

    this.state = { displayPopup: false, currentRoomId: null };
  }

  static propTypes = {
    rooms: PropTypes.array.isRequired,
    isLoading: PropTypes.bool
  };

  render() {
    const { rooms, isLoading } = this.props;

    const columns = [
      {
        Header: "Room Id",
        accessor: "id",
        Cell: props => <h3>{props.value}</h3>
      },
      {
        Header: "Places",
        accessor: "places",
        Cell: props => <h3>{props.value}</h3>
      },
      {
        Header: "Book",
        accessor: "id",
        Cell: props => (
          <Button
            onClick={() => {
              this.setState({ displayPopup: true, currentRoomId: props.value });
            }}
          >
            Book
          </Button>
        )
      }
    ];

    return (
      <div className="rooms-table">
        {this.state.displayPopup && (
          <BookingCreatorPopup
            roomId={this.state.currentRoomId}
            onClose={() => {
              this.setState({ displayPopup: false });
            }}
            onBookingCreate={this.props.onBookingCreate}
          />
        )}
        <Table
          data={rooms}
          columns={columns}
          loading={isLoading}
          defaultPageSize={5}
          resizable={false}
          showPageSizeOptions={false}
          minRows={0}
          showPagination={true}
          sortable={false}
        />
      </div>
    );
  }
}
