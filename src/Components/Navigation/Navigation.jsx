import React from "react";
import { NavLink } from "react-router-dom";
import Search from "../Search/Search";
const Navigation = () => {
  return (
    <div>
      <nav className="navbar navbar-default navbar-static-top">
        <ul className="nav nav-pills">
          <li>HCA</li>
          <li>
            <NavLink
              className="nav-link"
              to={"/covid19-videos"}
              exact
              activeClassName="active"
            >
              covid19-videos
            </NavLink>
          </li>
          <li>
            <NavLink
              className="nav-link"
              to={"/all-videos"}
              exact
              activeClassName="active"
            >
              All Videos
            </NavLink>
          </li>

          <li>
            <Search />
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Navigation;
