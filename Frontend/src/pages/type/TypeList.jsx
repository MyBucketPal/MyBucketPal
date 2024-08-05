
// itt lesz az összes adat fetch

import { useState, useEffect } from "react";


async function fetchAllTypeData() {
    try {
        const response = await fetch("/api/Type/all", {
            headers: { "Content-Type": "application/json" }
        });
        const dataJson = await response.json();
        return dataJson;
    } catch (error) {
        console.error("Error fetching solar data:", error);
        return null;
    }
}
async function deleteType (typeId)  {
    return fetch(`/api/Type/delete${typeId}`, { method: "DELETE" }).then((res) => res.json())
}

const onDelete = (typeId) => {
    console.log("Deleting type with id:", typeId);
    deleteType(typeId);
};


const TypeList = () => {
    const [loading, setLoading] = useState(true);
    const [typeList, setTypeList] = useState(null);

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
        <div>
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
                                <td>{type.descrition}</td>
                                
                                <td>
                                    <button type="button" onClick={() => onDelete(type.typeId)}>
                                        Delete
                                    </button>

                                </td>

                            </tr>
                        ))}

                    </tbody>
                </table>

            </div>
        </div>
    );
};

export default TypeList;