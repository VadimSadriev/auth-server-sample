import React from "react";
import { Navbar } from "../navbar";
import { Layout } from "antd";

export const MainLayout: React.FC = (props) => {
  return (
    <React.Fragment>
      <Navbar />
      <Layout.Content>{props.children}</Layout.Content>
    </React.Fragment>
  );
};
