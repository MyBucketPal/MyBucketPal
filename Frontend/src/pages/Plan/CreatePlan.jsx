import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const CreatePlan = () => {
  const [Title, setTitle] = useState("");
  const [Description, setDescription] = useState("");
  const [City, setCity] = useState("");
  const [seletedType, setSelectedType] = useState("");
  const [TypeId, setTypeId] = useState("");
  const [typeOptions, setTypeOptions] = useState([]);
  const [Private, setIsPrivate] = useState(false);
  const navigator = useNavigate();

  useEffect(() => {
    const fetchTypes = async () => {
      try {
        const response = await fetch("/api/Type/all");
        const data = await response.json();
        setTypeOptions(data);
        console.log(data);
      } catch (error) {
        console.error("error fetching types:", error);
      }
    };
    fetchTypes();
  }, []);
  const date = new Date().toISOString();
  console.log(date);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const fetchdata = {
      Title: Title,
      City: City,
      TypeId: TypeId,
      Description: Description,
      CreatedAt: date,
      Private: Private,
    };
    console.log(fetchdata);

    try {
      const response = await fetch("api/Plan/add", {
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
          <select value={seletedType} onChange={handleChange}>
            <option value="" disabled>
              Choose a type
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
};

export default CreatePlan;
