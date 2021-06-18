import React from "react";
import { UserManager, User } from 'oidc-client'

export interface authConfig {
    userManager: UserManager | null,
    login: Function,
    user: User | null,
    setUser: (user: User) => void
}

export const AuthContext = React.createContext<authConfig>({
    userManager: null,
    user: null,
    setUser: () => {
        throw new Error("Set user not implemented")
    },
    login: (user: User) => {
        throw new Error("Login not implemented")
    }
})
