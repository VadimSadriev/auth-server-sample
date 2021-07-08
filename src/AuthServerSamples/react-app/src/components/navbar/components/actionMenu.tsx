import React, { useState } from "react";
import { Menu } from "antd";
import { Link } from "react-router-dom";

export const ActionMenu: React.FC = (props) => {
  return (
    <Menu mode="horizontal" selectedKeys={[]}>
      <Menu.Item key="secured">
        <Link to="/secured">Secured</Link>
      </Menu.Item>
    </Menu>
  );
};
