import { Outlet } from 'react-router-dom';

const NoNavBarLayOut = () => {
    return (
        <div className="container">
            <main className="main">
                <Outlet />
            </main>
        </div>
    );
};

export default NoNavBarLayOut;