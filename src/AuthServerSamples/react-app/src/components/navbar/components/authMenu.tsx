import React, { useState } from "react";
import { Menu } from "antd";
import { AuthContext } from "../../../application/contexts/auth";
import { User } from "oidc-client";


export const AuthMenu: React.FC = (props) => {
    const { login, logout, user } = React.useContext(AuthContext);
    const [currentSelectedMenuItem, setSelectedMenuItem] = React.useState("");

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

    const logoutHandler = async () => {
        try {
            await logout()
        } catch (err) {
            console.log(err)
        }
    }

    if (user)
        return (
            <Menu key="authenticatedMenu" mode="horizontal" selectedKeys={[]}>
                <Menu.Item key="user">{user.profile.name}</Menu.Item>
                <Menu.Item key="logout">
                    <a onClick={logoutHandler}>Logout</a>
                </Menu.Item>
            </Menu>
        )

    return (
        <Menu key="notAuthenticatedMenu" mode="horizontal" selectedKeys={[]}>
            <Menu.Item key="login">
                <a onClick={loginHandler}>Login</a>
            </Menu.Item>
        </Menu>
    )
};
