import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actions as roomsActions } from "../../actions/rooms";

class Dashboard extends Component {
  componentWillMount() {
    const { roomsState, getRooms } = this.props;

    if (!roomsState.lastFetch) {
      getRooms();
    }
  }

  render() {
    const { roomsState } = this.props;

    return <div>{roomsState.rooms.map(room => room.id)}</div>;
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
