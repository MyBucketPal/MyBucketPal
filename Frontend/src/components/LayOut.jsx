import { createContext, useState } from "react";
import Navbar from "./NavBar.jsx";
import Footer from "./Footer.jsx";


export const DataContext = createContext(null);

export default function Layout() {
  const [globalData, setGlobalData] = useState(null);
  
  const handleLogout = () => {
    setGlobalData(null);
  };

  return (
    <DataContext.Provider value={{ globalData, setGlobalData }}>
      <Navbar username={globalData} onLogout={handleLogout} />
      <Footer />
    </DataContext.Provider>
  );
}