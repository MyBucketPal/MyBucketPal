import React, { useEffect, useState } from "react";

export default function UserSubscriptions() {
  const [subscriptions, setSubscriptions] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("api/AllData/MySubscriptions", {
          method: "GET",
          credentials: "include",
        });
        if (response.ok) {
          const data = await response.json();
          setSubscriptions(data);
          console.log(data);
        }
      } catch (error) {
        console.error(error);
      }
    };
    fetchData();
  }, []);

  return (
    <div>
      <h2>Subscriptions</h2>
      <ul>
        {subscriptions.map((subscription, index) => (
          <li key={index}>
            <h3>Plan Title: {subscription.plan.title}</h3>
            <p>City: {subscription.plan.city}</p>
            <p>Description: {subscription.plan.description}</p>
            <p>
              Plan Created At:{" "}
              {new Date(subscription.plan.createdAt).toLocaleString()}
            </p>
            <p>Type: {subscription.plan.type.description}</p>
            <p>
              Subscription Date:{" "}
              {new Date(subscription.subscriptionDate).toLocaleString()}
            </p>
            <p>Date From: {new Date(subscription.dateFrom).toLocaleString()}</p>
            <p>Date To: {new Date(subscription.dateTo).toLocaleString()}</p>
            <p>Is Completed: {subscription.isCompleted ? "Yes" : "No"}</p>
            <p>Is Private: {subscription.isPrivate ? "Yes" : "No"}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}
