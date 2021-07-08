import React, { useState, useEffect } from "react";
import { AuthContext } from "./authContext";
import { authConfig } from './authContext.Model'
import { authConfigToUserManagerSettingsMapper } from './authContext.Mappers'
import { UserManager, UserManagerSettings, User } from "oidc-client";

export const AuthProvider: React.FC<authConfig> = (props) => {

  var [user, setUser] = useState<User | null>(null);

  const userManagerSettings = authConfigToUserManagerSettingsMapper(props)

  const [userManager, setUserManager] = useState(new UserManager(userManagerSettings));

  const handleSetUser = (newUser: User) => {
    setUser(newUser);
  };

  useEffect(() => {
    loadUser();
  }, []);

  const loadUser = async () => {
    const user = await userManager.getUser();
    
    if (user)
      setUser(user);
  };

  return (
    <AuthContext.Provider
      value={{
        user: user,
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
