import React, { useEffect, useState } from "react";
import Subscription from "../../components/Subscription";

import { DataContext } from "../../components/LayOut";
import { useContext } from "react";
import { useNavigate } from "react-router-dom";
export default function Subscriptions() {
  const [subscriptions, setSubscriptions] = useState([]);
  const user = localStorage.getItem("user");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("api/AllData/allSubscribers");
        const data = await response.json();
        setSubscriptions(data);
        console.log(data);
      } catch (error) {
        console.error("error fetching types:", error);
      }
    };
    fetchData();
  }, []);

  const handleClick = (subscription) => {
    console.log(subscription);
    navigate("/subscriberDetail", { state: { subscription } });
  };

  return (
    <div>
      {subscriptions && (
        <Subscription subscriptions={subscriptions} handleClick={handleClick} />
      )}
    </div>
  );
}
