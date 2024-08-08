import React from "react";

export default function Subscription({ subscriptions, handleClick }) {
  return (
    <div>
      {subscriptions &&
        subscriptions.map((subscription) => (
          <div
            key={subscription.subscriberId}
            style={{
              ...planStyle,
              backgroundColor: "#f9f9f9",
            }}
            onClick={handleClick(subscription)}
          >
            <p>
              <strong>Title:</strong> {subscription.planDetailsDto.dateFrom}
            </p>
            <p>
              <strong>City:</strong> {subscription.planDetailsDto.dateTo}
            </p>
            <p>
              <strong>TypeID:</strong>{" "}
              {subscription.planDetailsDto.plansDto.city}
            </p>
            <p>
              <strong>Description:</strong>{" "}
              {subscription.planDetailsDto.typeDercription}
            </p>
          </div>
        ))}
    </div>
  );
}

const planStyle = {
  border: "1px solid #ccc",
  color: "blue",
  padding: "10px",
  margin: "10px 0",
  borderRadius: "5px",
  backgroundColor: "#f9f9f9",
};
