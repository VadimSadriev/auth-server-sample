import React from "react";
import { Menu } from "antd";
import { AuthContext } from "../../../application/contexts/auth";

export const AuthMenu: React.FC = (props) => {
  const { login, userManager } = React.useContext(AuthContext);

  const loginHandler = async (e: any) => {
    try {
      await login();
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Menu mode="horizontal">
      <Menu.Item key="login">
        <a onClick={loginHandler}>Login</a>
      </Menu.Item>
    </Menu>
  );
};
