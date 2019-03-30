import React from "react";
import ReactDOM from "react-dom";
import { hot } from "react-hot-loader";
import Dashboard from "./components/dashboard";
import store from "./store";
import { Provider } from "react-redux";

const target = document.querySelector("#root");
const HotDashboard = hot(module)(Dashboard);
const App = () => <HotDashboard />;

const root = (
  <Provider store={store}>
    <App />
  </Provider>
);

ReactDOM.render(root, target);
