
import { useState } from "react";
import { useParams } from "react-router-dom";
import "./TypeUpdater.css";




const TypeUpdater = () => {

    const [loading, setLoading] = useState(false);
    const [updated, setUpdated] = useState(false);
    const [description, setDescription] = useState('');
   
    const [message, setMessage] = useState('');

    const typeId = useParams().typeId;




    const updateType = async (e) => {
        e.preventDefault();
        setLoading(true);

        try {
            const response = await fetch('/api/Type/update', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ typeId, description }),
            });

            if (response.ok) {

                setUpdated(true);
                setMessage('Type updated');
            } else {
                setMessage('type not updated');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('type updated failed.');
        }
    };
    if (loading) {
        <div>Loading...  </div>
    }

    return (
        updated ? (
            <div>

                {message && <p className="message">{message}</p>}

            </div>

        ) :
            (
            <div>
                <form className="CreateType" onSubmit={updateType}>
                    <div className="control">
                        <label htmlFor="name">Type Id</label>
                        <input
                            value={typeId}
                            name="typeId"
                            id="TypeId"
                        />
                    </div>
                    <div className="control">
                        <label htmlFor="name">Description:</label>
                        <input
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            name="description"
                            id="TypeId"
                        />
                    </div>

                    <div className="buttons">
                        <button type="submit" >Update Type </button>

                    </div>
                </form>
                <p>majom</p>
            </div>)
    );
};

export default TypeUpdater;
