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
        <div>
            <h2>Register</h2>
            <form onSubmit={handleRegister}>
                <div>
                    <label>Username:</label>
                    <input
                        type="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password1"
                        value={password1}
                        onChange={(e) => setPassword1(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Comfirm Password:</label>
                    <input
                        type="password2"
                        value={password2}
                        onChange={(e) => setPassword2(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Birthdate</label>
                    <input
                        type="birthDate"
                        value={birthDate}
                        onChange={(e) => setBirthDate(e.target.value)}
                        placeholder="YYYY-MM-DD"
                        required
                    />
                </div>
                <button type="submit">Submit</button>

            </form>
            {message && <p>{message}</p>}
        </div>
    );
};

export default Register;