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
            onClick={() => handleClick(subscription)}
          >
            <p>
              <strong>From:</strong> {subscription.planDetailsDto.dateFrom}
            </p>
            <p>
              <strong>To:</strong> {subscription.planDetailsDto.dateTo}
            </p>
            <p>
              <strong>City:</strong> {subscription.planDetailsDto.plansDto.city}
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
