import React, { useState } from "react";
import { Menu } from "antd";
import { AuthContext } from "../../../application/contexts/auth";

export const AuthMenu: React.FC = (props) => {
  const { login, userManager, user } = React.useContext(AuthContext);
  const [currentSelectedMenuItem, setSelectedMenuItem] = React.useState("");

  console.log("user1: " , user)

  const loginHandler = async (e: any) => {
    try {
      setSelectedMenuItem("login");
      await login();
    } catch (error) {
      console.log(error);
    } finally {
      setSelectedMenuItem("");
    }
  };

  return (
    <Menu mode="horizontal" selectedKeys={[currentSelectedMenuItem]}>
      {user !== null ? (
        <Menu.Item key="user">{ user.profile.name}</Menu.Item>
       
      ) : (
        <Menu.Item key="login">
          <a onClick={loginHandler}>Login</a>
        </Menu.Item>
      )}
    </Menu>
  );
};
