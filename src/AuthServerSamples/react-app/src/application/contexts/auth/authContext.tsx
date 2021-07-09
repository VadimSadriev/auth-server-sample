import React from "react";
import { User } from 'oidc-client'
import { authSettings } from './authContext.Model'

export const AuthContext = React.createContext<authSettings>({
    userManager: null,
    user: null,
    setUser: () => {
        throw new Error("Set user not implemented")
    },
    login: (user: User) => {
        throw new Error("Login not implemented")
    },
    logout: () => {
        throw new Error("Logout is not implemented")
    },
    isAuthenticated: false
})
