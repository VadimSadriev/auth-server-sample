import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home, Secured, SignIn } from "./views";
import { AuthRoute } from './components';

export const Routes: React.FC = (props) => {
    return (
        <Switch>
            <Route exact path="/" component={Home}/>
            <AuthRoute exact path="/secured">
                <Secured/>
            </AuthRoute>
            <Route exact path="/signin" component={SignIn}/>
        </Switch>
    );
};
