import React from "react";
import { UserManager } from 'oidc-client'

export interface authConfig {
    userManager: UserManager | null,
    login: Function
}

export const AuthContext = React.createContext<authConfig>({
    userManager: null,
    login: () => {
        throw new Error("Login method not implemented")
    }
})
