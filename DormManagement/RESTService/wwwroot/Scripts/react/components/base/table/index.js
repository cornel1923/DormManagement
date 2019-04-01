/*
 * this component is basically a thin wrapper around react table
 * to allow the bespoke css and pagination behaviour to be in a single location
 */

import React from "react";

import ReactTable, { ReactTableDefaults } from "react-table";
import TablePagination from "./tablePagination";

import "./styles.css";

Object.assign(ReactTableDefaults, {
  PaginationComponent: TablePagination
});

const table = props => <ReactTable {...props} />;

export default table;
