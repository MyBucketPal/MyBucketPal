import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

export default function PlanEditor() {
  const location = useLocation();
  const { plan } = location.state || {};
  console.log(plan);

  const [Title, setTitle] = useState(plan?.title || "");
  const [Description, setDescription] = useState(plan?.description || "");
  const [City, setCity] = useState(plan?.city || "");
  const [TypeId, setTypeId] = useState(plan?.typeId || "");
  const [selectedType, setSelectedType] = useState("");
  const [typeOptions, setTypeOptions] = useState([]);
  const [Private, setIsPrivate] = useState(plan?.isPrivate || false);
  const [initialTypeDescription, setInitialTypeDescription] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchTypes = async () => {
      try {
        const response = await fetch("/api/Type/all");
        const data = await response.json();
        setTypeOptions(data);

        const initialTypeDescription = data.find(
          (t) => t.typeId == plan?.typeId
        );
        if (initialTypeDescription) {
          setInitialTypeDescription(initialTypeDescription.description);
        }
        console.log(data);
      } catch (error) {
        console.error("error fetching types:", error);
      }
    };
    fetchTypes();
  }, [plan?.typeId]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const fetchdata = {
      PlanId: plan.planId,
      Title: Title,
      City: City,
      TypeId: TypeId,
      Description: Description,
      createdAt: plan.createdAt,
      private: Private,
    };
    console.log(fetchdata);
    console.log("planid");
    console.log(plan.planId);

    try {
      const response = await fetch(`../api/Plan/update`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(fetchdata),
      });
      if (response.ok) {
        console.log("type added suxes");
        // navigator("/");
      }
    } catch (error) {
      console.error("message: ", error);
    }
  };

  const handleChange = (event) => {
    const selectedValue = event.target.value;
    const selectedObject = JSON.parse(selectedValue);
    console.log(selectedObject);
    setSelectedType(selectedObject);
    setTypeId(selectedObject.typeId);
  };

  useEffect(() => {
    console.log("typeId has changed:", TypeId);
  }, [TypeId]);

  const handleCheckboxChange = (event) => {
    setIsPrivate(event.target.checked);
  };

  return (
    <div>
      <p>Create Plan</p>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Title</label>
          <input
            type="text"
            value={Title}
            onChange={(e) => setTitle(e.target.value)}
          />
        </div>
        <div>
          <label>Description</label>
          <input
            type="text"
            value={Description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </div>
        <div>
          <label>Type</label>
          <select value={selectedType} onChange={handleChange}>
            <option value="" disabled>
              {initialTypeDescription || "Choose a type"}
            </option>
            {typeOptions.map((option, index) => (
              <option key={index} value={JSON.stringify(option)}>
                {option.description}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label>City</label>
          <input
            type="text"
            value={City}
            onChange={(e) => setCity(e.target.value)}
          />
        </div>
        <div>
          <label>Private plan</label>
          <input
            type="checkbox"
            value={Private}
            onChange={handleCheckboxChange}
          />
        </div>
        <button type="submit">Save Plan</button>
      </form>
    </div>
  );
}
