
import { useState } from "react";
import PieChart from '../../components/PieChart';


const TypeCreator = () => {
   
    const [loading, setLoading] = useState(false);
    const [created, setCreated] = useState(false);
    const [description, setDescription] = useState('');
    const [message, setMessage] = useState('');


   


    const createType = async (e) => {
        e.preventDefault();
        setLoading(true);
       
        try {
            const response = await fetch('/api/Type/add', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ description }),
            });

            if (response.ok) {

                setCreated(true);
                setMessage('Type created');
            } else {
                setMessage('type not created');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('type creation failed.');
        }
    };
    if (loading) {
        <div>Loading...  </div>
    }

    return (
        created ? (
            <div>
             
                {message && <p className="message">{message}</p>}

            </div>

        ) :
            (<div>
                <form className="CreateType" onSubmit={createType}>
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
                        <button type="submit" >Create Type </button>

                    </div>
                </form>
                <PieChart percent={29} />
             </div>)
    );
};

export default TypeCreator;
