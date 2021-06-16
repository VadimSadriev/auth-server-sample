import React, { useState } from "react";
import { ActionMenu, AuthMenu } from "./components";
import "./index.scss"

export const Navbar: React.FC = (props) => {
  return (
    <React.Fragment>
      <div className="main-nav-bar">
        <ActionMenu/>
        <AuthMenu />
      </div>
    </React.Fragment>
  );
};
