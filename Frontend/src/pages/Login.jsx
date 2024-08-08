import { useState, useContext } from "react";
import { DataContext } from "../components/LayOut.jsx";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");
  const { setGlobalData } = useContext(DataContext);
  //const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch("/api/Auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
      });

      if (response.ok) {
        //
        // Set the data of the logged in user here
        //
        const user = await response.json();
        console.log(user);
        setGlobalData(user);
        //('/aboutus');

        setMessage("Login successful.");
      } else {
        setMessage("Login failed.");
      }
    } catch (error) {
      console.error("Error:", error);
      setMessage("Login failed.");
    }
  };

  return (
    <div className="login-container">
      <h2 className="login-title">Login</h2>
      <form onSubmit={handleLogin} className="login-form">
        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input
            id="email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            className="form-input"
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password:</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            className="form-input"
          />
        </div>
        <button type="submit" className="submit-button">
          Login
        </button>
      </form>
      {message && <p className="message">{message}</p>}
    </div>
  );
};

export default Login;
