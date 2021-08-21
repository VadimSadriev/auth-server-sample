import React from "react";
import "./App.scss";
import { MainLayout } from "./components/layout";
import { WebStorageStateStore } from "oidc-client";
import { Routes } from "./routes";
import { BrowserRouter as Router } from "react-router-dom";
import "antd/dist/antd.css";
import { AuthProvider, authConfig } from "./application/contexts/auth";

const mockUser = {
  access_token: "",
  expired: false,
  expires_at: 12412412412412412,
  expires_in: 12412412412412412,
  id_token: "",
  scope: "openid profile",
  scopes: [],
  state: null,
  toStorageString: () => "",
  token_type: "Bearer",
  profile: {
    aud: "",
    exp: 12,
    iat: 1,
    iss: "",
    sub: "",
    name: "Ahri"
  }
}

console.log(process.env)

const oidcConfig: authConfig = {
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  authority: `${process.env.REACT_APP_AUTHORITY}`,
  client_id: `${process.env.REACT_APP_CLIENT_ID}`,
  redirect_uri: `${process.env.REACT_APP_REDIRECT_URI}`,
  response_type: "code",
  post_logout_redirect_uri: `${process.env.REACT_APP_POST_LOGOUT_REDIRECT_URI}`,
  scope: "openid profile",

  mockUser: null
};

function App() {
  return (
    <React.Fragment>
      <Router>
        <AuthProvider {...oidcConfig}>

          <MainLayout>
            <div className="App">
              <Routes />
            </div>
          </MainLayout>
        </AuthProvider>
      </Router>
    </React.Fragment>
  );
}

export default App;
