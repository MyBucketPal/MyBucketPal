const PlanTable = ({ planData, handleClickPrivate }) => (


    <div className="planTable">
        <table className="table">
            <thead>
                <tr className="tableRow">
                    <th>Title</th>
                    <th>City</th>
                    <th>Type</th>
                    <th>Description</th>
                    <th>Created at</th>
                    <th>isPrivate</th>
                </tr>
            </thead>
            <tbody>
                {planData.map((plan) => (
                    <tr key={plan.PlanId}>
                        <td>{plan.Title}</td>
                        <td>{plan.City}</td>
                        <td>{plan.Type.Description}</td>
                        <td>{plan.Description}</td>
                        <td>{plan.CreatedAt}</td>
                        <td><input type="checkbox" id={plan.PlanId} checked={plan.IsPrivate} onChange={handleClickPrivate} value={plan.IsPrivate}></input></td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
)

export default PlanTable;