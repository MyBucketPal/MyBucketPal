import { Link } from "react-router-dom";


export default function Navbar() {
  return (
    <nav className="Navbar">
      
   
      <Link to={"/aboutus"}>
        <button>What is it about</button>
      </Link>
      <Link to={"/photos"}>
        <button>Successes</button>
      </Link>
          <Link to={"/accomplished"}>
        <button>Accomplished</button>
      </Link>
       
        <>
          <Link to={"/signup"}>
            <button>SignUp</button>
          </Link>
          <Link to={"/login"}>
            <button>Login</button>
          </Link>
        </>
     
    </nav>
  );
}
