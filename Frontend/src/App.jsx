import './App.css'
import TestPage from './pages/Test';
import Login from './pages/Login';
import HomePage from './pages/HomePage';
import LayOut from './components/LayOut';
import { useRoutes } from 'react-router-dom';
import AboutUs from './pages/AboutUs';
import Register from './pages/Register';
import Logout from './pages/Logout';

const App = () => {
    const routes = useRoutes([
        {
            path: '/',
            element: <LayOut />,
            children: [
                { index: true, element: <HomePage /> },
                { path: 'login', element: <Login /> },
                { path: 'test', element: <TestPage /> },
                { path: 'aboutus', element: <AboutUs /> },
                { path: 'register', element: <Register /> },
                { path: 'logout', element: <Logout /> }
                // Add other routes here
            ],
        },
    ]);

    console.log('Routes:', routes);  // Temporary logging
    return routes;
};

export default App;