
// itt lesz az összes adat fetch

import { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';



async function fetchAllTypeData() {
    try {
        const response = await fetch("/api/Type/all", {
            headers: { "Content-Type": "application/json" }
        });
        const dataJson = await response.json();
        return dataJson;
    } catch (error) {
        console.error("Error fetching type data:", error);
        return null;
    }
}



const TypeList = () => {
    const [loading, setLoading] = useState(true);
    const [typeList, setTypeList] = useState(null);
    const [message, setMessage] = useState('');
    const [buttonPushed, setButtonPushed] = useState(false);

    const navigate = useNavigate();
    async function deleteType(typeId) {
        try {
            const response = await fetch(`/api/Type/delete${typeId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            if (response.ok) {

                setButtonPushed(true);
                setMessage('Type deleted');
            } else {
                setMessage('type not deleted');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('type delete failed.');
        }
    }



    const onDelete = async (typeId) => {
        console.log("Deleting type with id:", typeId);
        deleteType(typeId);
    };


    const onUpdate= async (typeId) => {
        console.log("updateing type with id:", typeId);
        navigate(`/typeUpdater/${typeId}`);
        
    };


    useEffect(() => {
        fetchAllTypeData().then((data) => {
            setTypeList(data);
            setLoading(false);
        });
    }, []);



    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        buttonPushed ? (
            <div>
                {message && <p className="message">{message}</p>}
            </div>
        ) :
            (<div>
                <div className="Table">
                    <table>
                        <thead>
                            <tr>
                                <th>TypeId</th>
                                <th>Description</th>
                                <th />
                            </tr>
                        </thead>
                        <tbody>
                            {typeList && typeList.map((type) => (
                                <tr key={type.typeId}>
                                    <td>{type.typeId}</td>
                                    <td>{type.description}</td>

                                    <td>
                                        <button type="button" onClick={() => onDelete(type.typeId)}>
                                            Delete
                                        </button>
                                        <button type="button" onClick={() => onUpdate(type.typeId)}>
                                            Update
                                        </button>
                                    </td>

                                </tr>
                            ))}

                        </tbody>
                    </table>

                </div>
            </div>)
    );
};

export default TypeList;