import React from "react";
import "./App.scss";
import { MainLayout } from "./components/layout";
import { WebStorageStateStore } from "oidc-client";
import { Routes } from "./routes";
import { BrowserRouter as Router } from "react-router-dom";
import "antd/dist/antd.css";
import { AuthProvider, authConfig } from "./application/contexts/auth";

const oidcConfig : authConfig = {
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  authority: "http://localhost:5000",
  client_id: "react_app_id",
  redirect_uri: "http://localhost:3000/signin",
  response_type: "code",
  post_logout_redirect_uri: "http://localhost:3000",
  scope: "openid profile",
};

function App() {
  return (
    <div>
      <AuthProvider {...oidcConfig}>
        <Router>
          <MainLayout>
            <div className="App">
              <Routes />
            </div>
          </MainLayout>
        </Router>
      </AuthProvider>
    </div>
  );
}

export default App;
