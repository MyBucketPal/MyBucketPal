import React from "react";

const Plans = ({ plans, handleClick }) => {
  return (
    <div>
      {plans &&
        plans.map((plan) => (
          <div
            key={plan.planId}
            style={{
              ...planStyle,
              backgroundColor: "#f9f9f9",
            }}
            onClick={() => handleClick(plan)}
          >
            <p>
              <strong>Title:</strong> {plan.title}
            </p>
            <p>
              <strong>City:</strong> {plan.city}
            </p>
            <p>
              <strong>TypeID:</strong> {plan.typeId}
            </p>
            <p>
              <strong>Description:</strong> {plan.description}
            </p>
          </div>
        ))}
    </div>
  );
};

const planStyle = {
  border: "1px solid #ccc",
  color: "blue",
  padding: "10px",
  margin: "10px 0",
  borderRadius: "5px",
  backgroundColor: "#f9f9f9",
};

export default Plans;
