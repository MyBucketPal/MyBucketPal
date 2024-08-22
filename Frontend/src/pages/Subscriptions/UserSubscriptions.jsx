import React, { useEffect, useState } from "react";

export default function UserSubscriptions() {
  const [subscriptions, setSubscriptions] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(
          "api/AllData/SubbscribersOnMySubscriptions",
          {
            method: "GET",
            credentials: "include",
          }
        );
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

  const listItemStyle = {
    backgroundColor: "white", // Fehér háttér
    color: "blue", // Kék betűszín
    padding: "10px", // Néhány extra stílus a jobb megjelenés érdekében
    marginBottom: "10px",
    borderRadius: "5px", // Lekerekített sarkok
    boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.1)",
    listStylePosition: "inside",
    position: "relative",
  };

  return (
    subscriptions && (
      <div>
        <h2>Subscriptions</h2>
        <ul>
          {subscriptions.map((subscription, index) => (
            <li key={index} style={listItemStyle}>
              <div>
                <h3>Plan Title: {subscription.planDetail.plan.title}</h3>
                <p>City: {subscription.planDetail.plan.city}</p>
                <p>Description: {subscription.planDetail.plan.description}</p>
                <p>
                  Plan Created At:{" "}
                  {new Date(
                    subscription.planDetail.plan.createdAt
                  ).toLocaleString()}
                </p>
                <p>Type: {subscription.planDetail.plan.type.description}</p>
                <p>
                  Subscription Date:{" "}
                  {new Date(
                    subscription.planDetail.subscriptionDate
                  ).toLocaleString()}
                </p>
                <p>
                  Date From:{" "}
                  {new Date(subscription.planDetail.dateFrom).toLocaleString()}
                </p>
                <p>
                  Date To:{" "}
                  {new Date(subscription.planDetail.dateTo).toLocaleString()}
                </p>
                <p>
                  Is Completed:{" "}
                  {subscription.planDetail.isCompleted ? "Yes" : "No"}
                </p>
                <p>
                  Is Private: {subscription.planDetail.isPrivate ? "Yes" : "No"}
                </p>

                <h4>Subscribers:</h4>
                <ul>
                  {subscription.subscribers.map((subscriber, subIndex) => (
                    <li key={subIndex}>
                      <p>Username: {subscriber.username}</p>
                    </li>
                  ))}
                </ul>
              </div>
            </li>
          ))}
        </ul>
      </div>
    )
  );
}
