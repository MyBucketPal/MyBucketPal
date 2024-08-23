import { Link } from "react-router-dom";
import "./NavBar.css";

export default function Navbar() {
  return (
    <nav className="Navbar">
      <Link to={"/aboutus"}>
        <button>About us</button>
      </Link>
      <Link to={"/photos"}>
        <button>Successes</button>
      </Link>
      <Link to={"/homePage"}>
        <button>HomePage</button>
      </Link>
      <Link to={"/register"}>
        <button>Register</button>
      </Link>
      <Link to={"/login"}>
        <button>Login</button>
      </Link>
      <Link to={"/logout"}>
        <button>Logout</button>
      </Link>
      <Link to={"/test"}>
        <button>Test</button>
      </Link>
      <Link to={"/createPlanDetail"}>
        <button>CreatePlanDetail</button>
      </Link>
      <Link to={"/createPlan"}>
        <button>CreatePlan</button>
      </Link>
      <Link to={"/bucketList"}>
        <button>Bucketlist</button>
      </Link>
      <Link to={"/MyBucketList"}>
        <button>My Bucketlist</button>
      </Link>
    </nav>
  );
}
