import React, { useEffect, useContext } from "react";
import { useHistory } from "react-router-dom";
import { AuthContext } from "../../application/contexts/auth";

export const SignIn: React.FC = (props) => {
  const { userManager } = useContext(AuthContext);

  const history = useHistory();

  useEffect(() => {
    handleCallBack();
  });

  const handleCallBack = async () => {
    try {
      await userManager?.signinCallback();
     
    } catch (error) {
      console.log(error);
    }
    finally{
        history.push('/')
    }
  };

  return null;
};
