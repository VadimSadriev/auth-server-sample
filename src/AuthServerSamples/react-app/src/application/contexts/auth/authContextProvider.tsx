import React, { useState } from "react";
import { AuthContext } from "./authContext";
import { UserManager, UserManagerSettings } from "oidc-client";

export const AuthProvider: React.FC<UserManagerSettings> = (props) => {
  const [userManager, setUserManager] = useState(new UserManager(props));

  return (
    <AuthContext.Provider
      value={{
        userManager: userManager,
        login: async () => {
          await userManager.signinRedirect();
        },
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};
