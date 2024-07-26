import { useState, useContext } from 'react';
import { DataContext } from "../components/LayOut.jsx";
import { useNavigate } from 'react-router-dom';

// fogalmam sincs, bocsi...


const Register = () => {
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password1, setPassword1] = useState('');
    const [password2, setPassword2] = useState('');
    const [birthDate, setBirthDate] = useState('');
    const [message, setMessage] = useState('');
    //const {setGlobalData} = useContext(DataContext);
    //const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();

        try {
            const Email = email
            const UserName = username
            const Password = password1
            const ConfirmPassword = password2
            const BirthDate = birthDate
            const response = await fetch('/api/Auth/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ UserName, Email, Password, ConfirmPassword, BirthDate }),
            });

            if (response.ok) {

                //
                // Set the data of the logged in user here
                //
                //const user = await response.json();
                //setGlobalData(user);
                //('/aboutus');


                setMessage('Register successful.');
            } else {
                setMessage('Register failed.');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('Register failed.');
        }
    };

    return (
        <div className="register-container">
          <h2 className="register-title">Register</h2>
          <form className="register-form" onSubmit={handleRegister}>
            <div className="form-group">
              <label>Username:</label>
              <input
                className="form-input"
                type="text"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
            </div>
            <div className="form-group">
              <label>Email:</label>
              <input
                className="form-input"
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
            </div>
            <div className="form-group">
              <label>Password:</label>
              <input
                className="form-input"
                type="password"
                value={password1}
                onChange={(e) => setPassword1(e.target.value)}
                required
              />
            </div>
            <div className="form-group">
              <label>Confirm Password:</label>
              <input
                className="form-input"
                type="password"
                value={password2}
                onChange={(e) => setPassword2(e.target.value)}
                required
              />
            </div>
            <div className="form-group">
              <label>Birthdate:</label>
              <input
                className="form-input"
                type="date"
                value={birthDate}
                onChange={(e) => setBirthDate(e.target.value)}
                required
              />
            </div>
            <button className="submit-button" type="submit">Submit</button>
          </form>
          {message && <p className="message">{message}</p>}
        </div>
      );
};


export default Register;