import React, { useContext } from 'react'
import { AuthContext } from "../../application/contexts/auth";
import { RouteProps, Route } from 'react-router-dom'
import { ErrorPage } from "../../views";

export const AuthRoute: React.FC<RouteProps> = ({ children, ...rest }) => {

    const { user } = useContext(AuthContext)

    if (!user)
        return (
            <Route {...rest}>
                <ErrorPage/>
            </Route>
        )

    return (
        <Route {...rest}>
            {children}
        </Route>
    )
}