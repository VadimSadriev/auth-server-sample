import React, { useState } from "react";
import { AuthContext } from "./authContext";
import { UserManager, UserManagerSettings, User } from "oidc-client";

export const AuthProvider: React.FC<UserManagerSettings> = (props) => {

  const [user, setUser] = useState<User | null>(null)

  const [userManager, setUserManager] = useState(new UserManager(props));

  const handleSetUser = (user: User) => {
    setUser(user);
  }

  return (
    <AuthContext.Provider
      value={{
        user: null,
        userManager: userManager,
        setUser: handleSetUser,
        login: async () => {
          await userManager.signinRedirect();
        },
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};
