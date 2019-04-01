import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import Moment from "moment";
import { actions as roomsActions } from "../../../actions/rooms";
import DateFilter from "../../base/datefilter";
import RoomsTable from "../../roomsTable";

import "./styles.css";

class Dashboard extends Component {
  constructor() {
    super();

    this.dateFrom = Moment().format("YYYY-MM-DD");
    this.dateTo = Moment().format("YYYY-MM-DD");
  }

  componentWillMount() {
    const { roomsState } = this.props;

    if (!roomsState.lastFetch) {
      this.getRoomsByDateRange();
    }
  }

  getRoomsByDateRange = () => {
    this.props.getRooms(this.dateFrom, this.dateTo);
  };

  render() {
    const { roomsState } = this.props;

    return (
      <div className="content">
        <h2>Get Available Rooms by Date Range:</h2>
        <DateFilter
          onChange={(start, end) => {
            this.dateFrom = start;
            this.dateTo = end;

            this.getRoomsByDateRange();
          }}
        />
        <br />
        <br />
        <RoomsTable
          rooms={roomsState.rooms}
          isLoading={roomsState.isLoading}
          onBookingCreate={() => {
            this.getRoomsByDateRange(this.dateFrom, this.dateTo);
          }}
        />
      </div>
    );
  }
}

const mapDispatchToProps = dispatch => ({
  getRooms: bindActionCreators(roomsActions.getRooms, dispatch)
});
const mapStateToProps = state => ({
  roomsState: state.rooms
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Dashboard);
