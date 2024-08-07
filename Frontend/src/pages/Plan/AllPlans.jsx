import React, { useEffect, useState } from "react";
import Plans from "../../components/Plans";
import { Link, useNavigate } from "react-router-dom";

export default function AllPlans() {
  const [plans, setPlans] = useState([]);
  const [clickedPlan, setClickedPlan] = useState(null);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("api/Plan/all", {
          method: "GET",
          credentials: "include",
          headers: {
            "Content-Type": "application/json",
          },
        });

        if (response.ok) {
          const data = await response.json();
          setPlans(data);
          console.log(data);
        } else {
          const errorText = await response.text();
          setError(`Error: ${response.status} - ${errorText}`);
          setPlans(null);
        }
      } catch (err) {
        setError(`Fetch error: ${err.message}`);
        setPlans(null);
      }
    };
    fetchData();
  }, []);

  const handleClick = (plan) => {
    console.log(plan);
    navigate(`/planEdit/${plan.planId}`, { state: { plan } });
  };

  return (
    <div>
      {plans ? (
        <Plans plans={plans} handleClick={handleClick} />
      ) : (
        <p>No plans available. Please try again later.</p>
      )}
      <div>
        <Link to="/createPlan">
          <button>Create something great!</button>
        </Link>
      </div>
    </div>
  );
}
