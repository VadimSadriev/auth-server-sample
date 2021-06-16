import React from "react";
import { Route, Switch } from "react-router-dom";
import { Home, Secured, SignIn } from "./views";

export const Routes: React.FC = (props) => {
  return (
    <Switch>
      <Route exact path="/" component={Home} />
      <Route exact path="/secured" component={Secured} />
      <Route exact path="/signin" component={SignIn} />
    </Switch>
  );
};
