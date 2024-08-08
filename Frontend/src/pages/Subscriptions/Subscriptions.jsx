import React, { useEffect, useState } from "react";
import Subscription from "../../components/Subscription";

export default function Subscriptions() {
  const [subscriptions, setSubscriptions] = useState([]);

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
    console.log(subscription.subscriberId);
  };

  return (
    <div>
      {subscriptions && (
        <Subscription subscriptions={subscriptions} handleClick={handleClick} />
      )}
    </div>
  );
}
