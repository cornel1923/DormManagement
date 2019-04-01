import React, { Component } from "react";
import { DateRangePicker } from "react-dates";
import Moment from "moment";

import "./styles.css";

class DateFilter extends Component {
  constructor(props) {
    super(props);

    this.state = {
      focusedInput: null,
      startDate: null,
      endDate: null
    };

    this.dateFormat = "YYYY-MM-DD";
  }

  onFocusChange(focusedInput) {
    this.setState(() => ({ focusedInput }));
  }

  render() {
    const { focusedInput, startDate, endDate } = this.state;

    return (
      <DateRangePicker
        startDate={startDate}
        endDate={endDate}
        startDatePlaceholderText="Date From"
        endDatePlaceholderText="Date To"
        focusedInput={focusedInput}
        onFocusChange={focusedInput => this.onFocusChange(focusedInput)}
        onDatesChange={({ startDate, endDate }) => {
          this.setState({ startDate, endDate });

          if (startDate && endDate) {
            this.props.onChange(
              startDate.utc().format(this.dateFormat),
              endDate.utc().format(this.dateFormat)
            );
          }
        }}
        firstDayOfWeek={1}
        displayFormat="DD/MM/YYYY"
        showClearDates
        showDefaultInputIcon
        hideKeyboardShortcutsPanel
        isDayBlocked={() => false}
        numberOfMonths={2}
        initialVisibleMonth={() => Moment().subtract(1, "months")}
      />
    );
  }
}

export default DateFilter;
