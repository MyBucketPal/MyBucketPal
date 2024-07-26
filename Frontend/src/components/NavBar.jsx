import { Link } from "react-router-dom";


export default function Navbar() {
  return (
    <nav className="Navbar">
   
      <Link to={"/aboutus"}>
        <button>About us</button>
      </Link>
      <Link to={"/photos"}>
        <button>Successes</button>
      </Link>
      <Link to={"/accomplished"}>
        <button>Accomplished</button>
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

    </nav>
  );
}
