import React, {useState, useEffect} from "react";
import {AuthContext} from "./authContext";
import {authConfig} from './authContext.Model'
import {authConfigToUserManagerSettingsMapper} from './authContext.Mappers'
import {UserManager, UserManagerSettings, User} from "oidc-client";
import {useHistory} from 'react-router-dom'

export const AuthProvider: React.FC<authConfig> = (props) => {

    const [user, setUser] = useState<User | null>(null);
    const userManagerSettings = authConfigToUserManagerSettingsMapper(props)
    const [userManager, setUserManager] = useState(new UserManager(userManagerSettings));
    const history = useHistory();

    const handleSetUser = (newUser: User) => {
        setUser(newUser);
    };

    useEffect(() => {
        initAuthData();
    }, []);

    const initAuthData = async () => {

        if (props.mockUser) {

            setUser(props.mockUser)
            return
        }

        const user = await userManager.getUser();

        if (user)
            setUser(user);
    };

    const handleLogin = async () => {
        try {

            if (props.mockUser) {
                setUser(props.mockUser)
                return
            }

            await userManager.signinRedirect();
        } catch (err) {
            console.log(err)
        }
    }

    const handleLogout = async () => {
        try {

            if (props.mockUser) {
                setUser(null)
                history.push('/')
                return
            }

            await userManager.signoutRedirect()
            setUser(null)

        } catch (err) {
            console.log(err)
        }
    }

    return (
        <AuthContext.Provider
            value={{
                user: user,
                userManager: userManager,
                setUser: handleSetUser,
                login: handleLogin,
                logout: handleLogout,
                isAuthenticated: user?.expired
            }}
        >
            {props.children}
        </AuthContext.Provider>
    );
};
