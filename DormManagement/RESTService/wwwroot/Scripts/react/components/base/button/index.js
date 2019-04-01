import React from "react";
import PropTypes from "prop-types";
import "./styles.css";

const Button = ({ loading, classes, disabled, children, onClick }) => (
  <button
    className={`button ${classes}`}
    onClick={onClick}
    disabled={loading || disabled}
  >
    {loading ? "Loading" : children}
  </button>
);

Button.PropTypes = {
  loading: PropTypes.bool,
  classes: PropTypes.string,
  to: PropTypes.string
};

export default Button;
