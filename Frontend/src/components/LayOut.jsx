import { createContext } from "react";
import NavBar from "./NavBar.jsx";
//import Footer from "./Footer.jsx";
import { Outlet } from "react-router-dom";

export const DataContext = createContext(null); // user object{userId: 1, username: 'admin', email: 'admin@example.com', premium: false, birthDate: '2000-01-01T00:00:00', …}

const Layout = () => {
  return (
    <div className="container">
      <NavBar className="header" />
      <main className="main">
        <Outlet />
      </main>
  
    </div>
  );
};

export default Layout;
