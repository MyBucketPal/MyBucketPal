/*
{
    "planId": 0,
    "subscriptionDate": "2024-08-06T12:06:18.108Z",
    "dateFrom": "2024-08-06T12:06:18.108Z",
    "dateTo": "2024-08-06T12:06:18.108Z",
    "isCompleted": true,
    "isPrivate": true
  }
 */

import { useContext, useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { DataContext } from "../../components/LayOut";

const CreatePlanDetail = () => {
  const [planId, setPlanId] = useState("");
  const [dateFrom, setDateFrom] = useState("");
  const [dateTo, setDateTo] = useState("");
  const [isPrivate, setIsPrivate] = useState(false);
  const [plans, setPlans] = useState([]);
  const [clickedPlan, setClickedPlan] = useState(null);
  const [error, setError] = useState(null);

  const { globalData } = useContext(DataContext);
  console.log(globalData);
  const navigate = useNavigate();
  const user = JSON.parse(localStorage.getItem("user"));
  console.log(user);

  //GET ALL PLANS
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
    setClickedPlan(plan);
    setPlanId(plan.planId);
    console.log(plan.planId);
    console.log("Selected Plan:", plan);
  };

  const handleCheckboxChange = (event) => {
    setIsPrivate(event.target.checked);
  };

  const AddSubscription = async (idInDb) => {
    try {
      console.log("addsubscriberrsben");

      const userId = user.userId;
      const fetchData = {
        PlanDetailId: idInDb,
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
      }
    } catch (err) {
      setError(`Fetch error: ${err.message}`);
      setPlans(null);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (planId == "") {
      alert("noplan choosen");
    }

    try {
      const response = await fetch("api/PlanDetail/add", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          planId,
          subscriptionDate: new Date().toISOString(),
          dateFrom,
          dateTo,
          isCompleted: false,
          isPrivate,
        }),
      });
      if (response.ok) {
        console.log("type added suxes");
        const data = await response.json();
        console.log(data);
        const idInDb = data.detailId;
        await AddSubscription(idInDb);
        //navigate("/subscriptions");
      }
    } catch (error) {
      console.error("message: ", error);
    }
  };

  return (
    <div>
      <div>
        {plans && plans.length > 0 ? (
          <form onSubmit={handleSubmit}>
            <div>
              <label>Set start date</label>
              <input
                type="date"
                value={dateFrom}
                onChange={(e) => setDateFrom(e.target.value)}
              />
            </div>
            <div>
              <label>Set end date</label>
              <input
                type="date"
                value={dateTo}
                onChange={(e) => setDateTo(e.target.value)}
              />
            </div>
            <div>
              <label>Private plan</label>
              <input
                type="checkbox"
                value={isPrivate}
                onChange={handleCheckboxChange}
              />
            </div>
            <div>
              <div style={containerStyle}>
                <h1>Choose your plan</h1>
                {plans.map((plan) => (
                  <div
                    key={plan.planId}
                    style={{
                      ...planStyle,
                      backgroundColor:
                        clickedPlan && clickedPlan.planId === plan.planId
                          ? "#a3a3d3"
                          : "#f9f9f9",
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
            </div>
            {plans && <button type="submit">Save Plan</button>}
          </form>
        ) : (
          <div>
            <p>Please login to set up your dreams</p>
            <Link to="/login">
              <button>Login</button>
            </Link>
          </div>
        )}
      </div>
    </div>
  );
};

const containerStyle = {
  display: "flex",
  flexDirection: "column",
  alignItems: "stretch",
  maxHeight: "80vh", // maximum height of the container
  overflowY: "auto", // enable vertical scrolling
};

const planStyle = {
  border: "1px solid #ccc",
  color: "blue",
  padding: "10px",
  margin: "10px 0",
  borderRadius: "5px",
  backgroundColor: "#f9f9f9",
  cursor: "pointer",
};

export default CreatePlanDetail;
