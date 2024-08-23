
import { DataContext } from "../components/LayOut";
import { useContext } from "react";
import "./HomePage.css";


export default function HomePage() {

    const { globalData } = useContext(DataContext);
    console.log(globalData);

  return (
      <div className="homepage">
          <img src="/images/bucketpal.png" alt="logo" className="header-logo" />
      <header className="header">
              <h1 className="header-title">
                  Hello {globalData && globalData.username}!
         
                  
              </h1>
              <h1>MyBucketPal </h1>
        <h2 className="header-subtitle">Let the adventure begin!</h2>
        <aside className="quote">
          <i>Make your goals come true!</i>
        </aside>
      </header>
    </div>
  );
}