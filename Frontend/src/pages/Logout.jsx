
import { useNavigate } from 'react-router-dom';

const Logout = () => {
  const navigate = useNavigate();

  const handleLogout = async () => {
    try {
      const response = await fetch('/api/Auth/logout', {
        method: 'POST',
        credentials: 'include',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (response.ok) {
        alert('Logout successful.');
        navigate('/');
      } else {
        const errorText = await response.text();
        console.error(`Error: ${response.status} - ${errorText}`);
        navigate('/');
      }
    } catch (err) {
      console.error(`Fetch error: ${err.message}`);
      navigate('/'); 
    }
  };

  const handleCancel = () => {
    navigate('/'); 
  };

  return (
    <div className="logout-container">
      <h1>Are you sure you want to log out?</h1>
      <div className="button-container">
        <button onClick={handleLogout} className="logout-button">Yes</button>
        <button onClick={handleCancel} className="logout-button">No</button>
      </div>
    </div>
  );
};

export default Logout;