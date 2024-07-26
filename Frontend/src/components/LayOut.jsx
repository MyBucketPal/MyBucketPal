import { createContext, useState } from "react";
import NavBar from "./NavBar.jsx";
import Footer from "./Footer.jsx";
import { Outlet } from 'react-router-dom';


export const DataContext = createContext(null);

const Layout = () => {
    return (
        <div className="container">
            <NavBar className="header"/>
                <main className="main">
                <Outlet />
                </main>
            <Footer />
        </div>
    );
};

export default Layout;