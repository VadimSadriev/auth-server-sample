import React, { useState, useEffect } from "react";
import { AuthContext } from "./authContext";
import { UserManager, UserManagerSettings, User } from "oidc-client";

export const AuthProvider: React.FC<UserManagerSettings> = (props) => {
  var [user, setUser] = useState<User | null>(null);

  const [userManager, setUserManager] = useState(new UserManager(props));

  const handleSetUser = (newUser: User) => {
    setUser(newUser);
  };

  useEffect(() => {
    loadUser();
  }, []);

  const loadUser = async () => {
    const user = await userManager.getUser();
    if (user) setUser(user);
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
