import React from "react";
import { useLocation, useNavigate } from "react-router-dom";

export default function SubscriptionDetail() {
  const location = useLocation();
  const { subscription } = location.state;
  const navigate = useNavigate();

  const handleBack = () => {
    navigate("/bucketList");
  };

  const handleClick = async () => {
    try {
      console.log("addsubscriberrsben");
      const user = JSON.parse(localStorage.getItem("user"));
      console.log("user");
      console.log(user);
      const userId = user.userId;
      const fetchData = {
        PlanDetailId: subscription.planDetailsDto.detailId,
        UserId: userId,
      };
      const response = await fetch("api/Subscriber/add", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(fetchData),
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        alert("you subscribed!");
        navigate("/bucketList");
      }
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div
      key={subscription.subscriberId}
      style={{
        ...planStyle,
        backgroundColor: "#f9f9f9",
      }}
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
      <p>
        <strong>Title:</strong> {subscription.planDetailsDto.plansDto.title}
      </p>
      <p>
        <strong>Description:</strong>{" "}
        {subscription.planDetailsDto.plansDto.description}
      </p>
      <p>
        <strong>Type:</strong>{" "}
        {subscription.planDetailsDto.plansDto.typeDescription}
      </p>
      <button onClick={() => handleClick()}>subscribe</button>
      <button onClick={handleBack}>back</button>
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
